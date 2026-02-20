using TQproject.Domain.Entities;

namespace TQInventory.Domin.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public string ColumnLetter { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}