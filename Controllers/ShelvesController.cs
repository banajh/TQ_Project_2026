using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TQInventory.Domin.Entities;
using TQInventory.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace TQInventory.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly IShelfRepository _shelfRepo;
        private readonly IWarehouseRepository _warehouseRepo;

        public ShelvesController(IShelfRepository shelfRepo, IWarehouseRepository warehouseRepo)
        {
            _shelfRepo = shelfRepo;
            _warehouseRepo = warehouseRepo;
        }

        // GET: Shelves
        public async Task<IActionResult> Index()
        {
            var shelves = await _shelfRepo.GetAllAsync();
            return View(shelves);
        }

        // GET: Shelves/Create
        public async Task<IActionResult> Create()
        {
            await LoadWarehouses();
            return View();
        }

        // POST: Shelves/Create
        [HttpPost]
        public async Task<IActionResult> Create(Shelf shelf)
        {
            if (shelf.WarehouseId == 0) // تحقق من اختيار المستودع
            {
                await LoadWarehouses();
                TempData["Error"] = "Please select a warehouse!";
                return View(shelf);
            }

            await _shelfRepo.AddAsync(shelf); // حفظ البيانات
            return RedirectToAction(nameof(Index));
        }

        // ميثود مساعدة لتحميل المستودعات للـ Dropdown
        private async Task LoadWarehouses(int selectedId = 0)
        {
            var warehouses = await _warehouseRepo.GetAllAsync();
            ViewBag.Warehouses = new SelectList(warehouses, "Id", "Name", selectedId);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var shelf = await _shelfRepo.GetByIdAsync(id);
            if (shelf == null)
                return NotFound();

            return View(shelf);
        }

        // POST: Shelves/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _shelfRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
