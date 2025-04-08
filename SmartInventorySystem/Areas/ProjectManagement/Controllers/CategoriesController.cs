using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.Extensions.Logging;
using SmartInventorySystem.Data;
using SmartInventorySystem.Models;
using SmartInventorySystem.Areas.ProjectManagement.Models;



namespace SmartInventorySystem.Areas.ProjectManagement.Controllers
{
    
    // Controller to manage categories in the inventory system
    [Area("ProjectManagement")]
    [Route("[area]/[controller]/[action]")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ApplicationDbContext _context; // Database context for accessing categories

        // Constructor to inject ApplicationDbContext (Dependency Injection)
        public CategoriesController(ApplicationDbContext context, ILogger<CategoriesController> logger)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Categories
        // Retrieves and displays all categories
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Accessed ProjectController Index at {Time}", DateTime.Now);
            //Databased --> Retrieve a list of projects from database 
            var categories = await _context.Categories.ToListAsync();
            return View(categories); // Fetches all categories from the database
        }

        // GET: Categories/Create
        // Displays the category creation form
        public IActionResult Create()
        {
            _logger.LogInformation("Accessed ProjectController Create at {Time}", DateTime.Now);
            return View();
        }

        // POST: Categories/Create
        // Handles the submission of the category creation form
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents CSRF attacks
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid) // Validates model data before saving
            {
                _context.Add(category); // Adds category to the database
                await _context.SaveChangesAsync(); // Saves changes asynchronously
                return RedirectToAction(nameof(Index)); // Redirects to the list of categories
            }
            return View(category); // If validation fails, redisplay the form
        }

        // GET: Categories/Edit/{id}
        // Displays the category edit form for the specified ID
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // If no ID is provided, return a 404 error
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id); // Fetches the category
            if (category == null) // If category does not exist, return 404 error
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/{id}
        // Handles the submission of the category edit form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id) // Ensures the category ID matches
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(category); // Updates the category in the database
                await _context.SaveChangesAsync(); // Saves changes asynchronously
                return RedirectToAction(nameof(Index)); // Redirects to category list
            }
            return View(category); // If validation fails, redisplay the form
        }

        // GET: Categories/Delete/{id}
        // Displays the delete confirmation page for the specified ID
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // If no ID is provided, return 404 error
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m!.Id == id); // Finds the category by ID
            if (category == null) // If category does not exist, return 404 error
            {
                return NotFound();
            }

            return View(category); // Displays the delete confirmation page
        }

        // POST: Categories/Delete/{id}
        // Confirms and processes category deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id); // Finds the category by ID
            if (category != null)
            {
                _context.Categories.Remove(category); // Removes the category
                await _context.SaveChangesAsync(); // Saves changes asynchronously
            }

            return RedirectToAction(nameof(Index)); // Redirects to category list
        }
    }
}
