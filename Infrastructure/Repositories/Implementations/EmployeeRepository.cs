using TQInventory.Domin.Entities;
using TQInventory.Infrastructure.Repositories.Interfaces;
using TQproject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


namespace TQInventory.Infrastructure.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ProductDbContext _context;

        public EmployeeRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
            
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
    }
}