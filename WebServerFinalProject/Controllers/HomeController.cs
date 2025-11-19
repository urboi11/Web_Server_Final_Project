using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebServerFinalProject.Data;
using WebServerFinalProject.Models;

namespace WebServerFinalProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        List<Recipe> returnedAmount = _dbContext.Recipes.Take(4).ToList();
        if (returnedAmount.IsNullOrEmpty())
        {
            return View();
        }
        return View(returnedAmount);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // Placeholder actions for additional pages 
    public IActionResult AboutHobby() => View();
    public IActionResult AboutUs() => View();

}
