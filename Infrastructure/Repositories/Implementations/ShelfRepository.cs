using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TQInventory.Domin.Entities;
using TQInventory.Infrastructure.Repositories.Interfaces;
using TQproject.Domain.Entities;
using TQproject.Infrastructure.Database;
namespace TQInventory.Infrastructure.Repositories.Implementations
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly ProductDbContext _context;

        public ShelfRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Shelf>> GetAllAsync()
        {
            return await _context.Shelves.Include(s => s.Warehouse).Include(s => s.Products).ToListAsync();
        }

        public async Task<Shelf> GetByIdAsync(int id)
        {
            return await _context.Shelves.Include(s => s.Warehouse).Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shelf shelf)
        {
            _context.Shelves.Update(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shelf = await _context.Shelves.FindAsync(id);
            if (shelf != null)
            {
                _context.Shelves.Remove(shelf);
                await _context.SaveChangesAsync();
            }
        }
    }
}