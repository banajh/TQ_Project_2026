using System;

namespace TQInventory.Domin.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }
    }
}