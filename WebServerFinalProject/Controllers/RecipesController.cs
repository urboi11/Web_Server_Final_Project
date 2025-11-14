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

        public RecipesController(IRecipeService recipeService, ICategoryService categoryService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string? q, string? difficulty)
        {
            // return View();
            var recipes = await _recipeService.GetAllRecipesAsync(q, difficulty); // Use service to fetch data
            return View(recipes); // Pass the data to the view
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
