using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TQInventory.Domin.Entities;
using TQInventory.Infrastructure.Repositories.Interfaces;
using TQproject.Domain.Entities;

namespace TQInventory.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly IWarehouseRepository _warehouseRepo;

        public WarehousesController(IWarehouseRepository warehouseRepo)
        {
            _warehouseRepo = warehouseRepo;
        }

        public async Task<IActionResult> Index()
        {
            var warehouses = await _warehouseRepo.GetAllAsync();
            return View(warehouses);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Warehouse warehouse)
        {
            await _warehouseRepo.AddAsync(warehouse);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var warehouse = await _warehouseRepo.GetByIdAsync(id);
            if (warehouse == null) return NotFound();
            return View(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Warehouse warehouse)
        {
            await _warehouseRepo.UpdateAsync(warehouse);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var warehouse = await _warehouseRepo.GetByIdAsync(id);
            if (warehouse == null) return NotFound();
            return View(warehouse);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _warehouseRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
