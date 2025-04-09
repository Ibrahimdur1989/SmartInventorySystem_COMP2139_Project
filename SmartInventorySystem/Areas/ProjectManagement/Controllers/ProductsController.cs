using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.Extensions.Logging;
using SmartInventorySystem.Data;
using SmartInventorySystem.Models;
using SmartInventorySystem.Areas.ProjectManagement.Models;

namespace SmartInventorySystem.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]
    [Route("[area]/[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Accessed ProductsController Index at {Time}", DateTime.Now);
            
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            PopulateCategoryDropdown();
            var categories = _context.Categories.ToList();
            if (!categories.Any())
            {
                ViewBag.NoCategories = "No categories found. Please add a category first.";
            }
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        //  POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,QuantityInStock,LowStockThreshold,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var categories = _context.Categories.ToList();
            if (!categories.Any())
            {
                ViewBag.NoCategories = "No categories found. Please add a category first.";
            }
            PopulateCategoryDropdown(product.CategoryId);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        //  GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductId, [Bind("ProductId,Name,Price,QuantityInStock,LowStockThreshold,CategoryId")] Product product)
        {
            if (ProductId != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // !ProductExists(product.ProductId)
                    if (!_context.Products.Any(e => e.ProductId == product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        //  GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _logger.LogInformation("Accessed ProductsController Details at {Time}", DateTime.Now);
            
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                _logger.LogWarning("Could not find Products with id of {id}", id);
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
        
        private void PopulateCategoryDropdown(int? selectedId = null)
        {
            var categories = _context.Categories.ToList();
            if (!categories.Any())
                ViewData["NoCategories"] = "No categories found. Please add a category first.";

            ViewData["Categories"] = new SelectList(categories, "Id", "Name", selectedId);
        }
    }
}
