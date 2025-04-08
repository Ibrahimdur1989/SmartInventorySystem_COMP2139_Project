using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartInventorySystem.Areas.ProjectManagement.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string GuestName { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Enforce UTC

        [Required]
        public decimal TotalPrice { get; set; } = 0;

        [Required]
        public string Status { get; set; } = "Pending";

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        
        public void CalculateTotalPrice()
        {
            TotalPrice = OrderItems.Sum(item => item.Price);
        }
    }
}