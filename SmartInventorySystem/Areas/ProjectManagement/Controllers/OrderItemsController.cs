using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.Extensions.Logging;
using SmartInventorySystem.Data;
using SmartInventorySystem.Models;
using SmartInventorySystem.Areas.ProjectManagement.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartInventorySystem.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    [Route("[area]/[controller]/[action]")]
    public class OrderItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            var orderItems = _context.OrderItems
                .Include(o => o.Product)
                .Include(o => o.Order)
                .ToListAsync();
            return View(await orderItems);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewBag.Orders = new SelectList(_context.Orders, 
                "Id", "Id");
            ViewBag.Products = new SelectList(_context.Products, 
                "ProductId", "Name");
            return View();
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity,Price")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Orders = new SelectList(_context.Orders, "Id", "Id");
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "Name");
            return View(orderItem);
        }
    }
}