using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Data;
using SmartInventorySystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartInventorySystem.Controllers
{
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
            var orderItems = _context.OrderItems.Include(o => o.Product).Include(o => o.Order);
            return View(await orderItems.ToListAsync());
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewBag.Orders = new SelectList(_context.Orders, "Id", "Id");
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name");
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

            ViewBag.Orders = new SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }
    }
}