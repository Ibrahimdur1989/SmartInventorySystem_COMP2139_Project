using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Data;
using SmartInventorySystem.Models;

namespace SmartInventorySystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        public IActionResult Create()
        {
            ViewBag.Orders = new SelectList(_context.Orders, "Id", "OrderDate");
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

    }

}
