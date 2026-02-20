using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TQInventory.Domin.Entities;
using TQInventory.Infrastructure.Repositories.Implementations;
using TQInventory.Infrastructure.Repositories.Interfaces;

namespace TQInventory.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IShelfRepository _shelfRepo;

        public ProductsController(IProductRepository productRepo, IShelfRepository shelfRepo)
        {
            _productRepo = productRepo;
            _shelfRepo = shelfRepo;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
           
                await _productRepo.AddAsync(product);
                return RedirectToAction(nameof(Index));
             
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            
                await _productRepo.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
             

            return View(product);
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var product = await _productRepo.GetByIdAsync(id);
        //    if (product == null)
        //        return NotFound();

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _productRepo.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}


        // GET: Product/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Delete/3
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
