using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Models;
using SmartInventorySystem.Areas.ProjectManagement.Models;

namespace SmartInventorySystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // 👈 Use ApplicationUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}