using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TQInventory.Domin.Entities;
using TQInventory.Infrastructure.Repositories.Interfaces;
using TQproject.Domain.Entities;

namespace TQInventory.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepo.GetAllAsync();
            return View(employees);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await _employeeRepo.AddAsync(employee);
            return RedirectToAction(nameof(Index));
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepo.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            await _employeeRepo.UpdateAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepo.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
