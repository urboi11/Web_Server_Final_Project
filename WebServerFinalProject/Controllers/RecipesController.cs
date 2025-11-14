using Microsoft.AspNetCore.Mvc;
using WebServerFinalProject.Models;
using WebServerFinalProject.Services;
using System.Threading.Tasks;

namespace WebServerFinalProject.Controllers
{
    public class RecipesController : Controller
    {
        // /Recipes
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
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
