using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin, RegularUser")]
    public class OrderItemsController : Controller
    {
        private readonly ILogger<OrderItemsController> _logger;
        private readonly ApplicationDbContext _context;

        public OrderItemsController(ApplicationDbContext context, ILogger<OrderItemsController> logger)
        {
            _context = context;
            _logger = logger;
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
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(orderItem);
                    await _context.SaveChangesAsync();
                    
                    _logger.LogInformation("Order item created");
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Order item creation failed");
                TempData["Error"] = "Something went wrong";
            }

            ViewBag.Orders = new SelectList(_context.Orders, "Id", "Id");
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "Name");
            return View(orderItem);
        }
    }
}
