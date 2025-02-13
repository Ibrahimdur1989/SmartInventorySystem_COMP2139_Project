namespace SmartInventorySystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int LowStockThreshold { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}