using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartInventorySystem.Models;

namespace SmartInventorySystem.Controllers;

// HomeController handles navigation to primary pages like Index and Privacy
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger; // Logger for debugging and error tracking

    // Constructor to initialize the logger via dependency injection
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Handles requests for the homepage ("/" or "/Home/Index")
    public IActionResult Index()
    {
        _logger.LogTrace("Accessed HomeController Index at {Time}", DateTime.Now);
        return View(); // Returns the corresponding Index.cshtml view
    }

    // Handles requests for the privacy policy page ("/Home/Privacy")
    public IActionResult Privacy()
    {
        _logger.LogInformation("Accessed HomeController Privacy at {Time}", DateTime.Now);
        return View(); // Returns the corresponding Privacy.cshtml view
    }

    // Handles errors and displays the Error page when an exception occurs
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? statusCode = null)
    {
        _logger.LogError("Accessed HomeController Error at {Time}", DateTime.Now);

        if (statusCode.HasValue)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }
            else if (statusCode == 500)
            {
                return View("ServerError");
            }
        }
        return View("ServerError");
    }

    
    [HttpGet]
    public IActionResult GeneralSearch(string searchType, string searchString)
    {
        _logger.LogInformation("Accessed HomeController General Search at {Time}", DateTime.Now);
        // Ensure searchType is not null and handle case--insensitivity 
        searchType = searchType.ToLower();

        // Determine where to redirect based on search type 
        if (searchType == "projects")
        {
            // Redirect to Project search
            return RedirectToAction("Search", "Products", new { area = "ProjectManagement", searchString });
        }    
        else if (searchType == "tasks")
        {
            // Redirect to ProjectTask search
            return RedirectToAction("Search", "OrderItems", new { area = "ProjectManagement", searchString });
                
        }
        
        return RedirectToAction("Index", "Home");
        
    }

    [HttpGet]
    public IActionResult NotFound(int statusCode)
    {
        _logger.LogError("NotFound invoked at {Time}", DateTime.Now);
        if (statusCode == 404)
        { 
            return View("NotFound");
        }
        return View("Error");
    }
    
    
}
