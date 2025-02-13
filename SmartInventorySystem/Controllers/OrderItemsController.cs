using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Data;
using SmartInventorySystem.Models;

namespace SmartInventorySystem.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orderItems = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToListAsync();
            return View(orderItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItems.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null) return NotFound();
            return View(orderItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null) return NotFound();
            return View(orderItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
