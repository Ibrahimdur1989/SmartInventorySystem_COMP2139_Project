using System.Collections.Generic;
using SmartInventorySystem.Models;



namespace SmartInventorySystem.Areas.ProjectManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}