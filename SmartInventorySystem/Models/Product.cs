using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartInventorySystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int QuantityInStock { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LowStockThreshold { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}