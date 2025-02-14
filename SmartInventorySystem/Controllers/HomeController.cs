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
        return View(); // Returns the corresponding Index.cshtml view
    }

    // Handles requests for the privacy policy page ("/Home/Privacy")
    public IActionResult Privacy()
    {
        return View(); // Returns the corresponding Privacy.cshtml view
    }

    // Handles errors and displays the Error page when an exception occurs
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Creates an instance of ErrorViewModel and assigns the current request ID
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}