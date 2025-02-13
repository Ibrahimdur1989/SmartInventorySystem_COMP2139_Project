namespace SmartInventorySystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        // Foreign Key
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}