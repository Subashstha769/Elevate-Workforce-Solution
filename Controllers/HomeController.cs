using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebLab2024.Models;

namespace WebLab2024.Controllers;

// HomeController handles various requests related to the home page and other views.
public class HomeController : Controller
{
    // Logger for capturing application logs
    private readonly ILogger<HomeController> _logger;

    // Constructor to initialize the logger
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Action method to load the Index view
    public IActionResult Index()
    {



        return View();
    }

    // Handles POST request for Details page

    [HttpPost]

    public IActionResult Details(PersonModel pm)

    {

        return View(pm);
    }

    // Action method for the Privacy page

    public IActionResult Privacy()
    {
        return View();
    }

    // Action method for the About page
    public IActionResult About()
    {
        return View();
    }
    // Handles errors and returns the Error view with request details


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
