using Microsoft.AspNetCore.Mvc;

namespace WebServerFinalProject.Controllers
{
    public class RecipesController : Controller
    {
        // /Recipes
        public IActionResult Index(string? q, string? difficulty)
        {
            return View();
        }

        // /Recipes/Season
        public IActionResult Season(string? category)
        {
            return View();
        }

        // /Recipes/Type
        public IActionResult Type(string? type)
        {
            return View();
        }

        // /Recipes/Details
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
