using System;
using System.Collections.Generic;

namespace SmartInventorySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal TotalPrice 
        { 
            get 
            { 
                decimal total = 0;
                foreach (var item in OrderItems)
                {
                    total += item.Quantity * item.Product.Price;
                }
                return total;
            }
        }
    }
}