using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebLab2024.Models;

namespace WebLab2024.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // This is the one way of making object 

        // var person = new PersonModel();
        // person.FirstName="Subash";
        // person.LastName="Shrestha";
        // person.PhoneNumber="9860119331";
        // person.Email="subashstha769@gmail.com";

        
        return View();
    }
    [HttpPost]
    
    public IActionResult Details(PersonModel pm)

    {

        return View(pm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
