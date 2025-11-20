using Microsoft.AspNetCore.Mvc;
using WebServerFinalProject.Models;
using WebServerFinalProject.Services;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WebServerFinalProject.Data;

namespace WebServerFinalProject.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        // /Recipes
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public RecipesController(ApplicationDbContext dbContext, IRecipeService recipeService, ICategoryService categoryService)
        {
            _dbContext = dbContext;
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult<List<Recipe>>> Index(string? q, string? difficulty)
        {
            if (!q.IsNullOrEmpty())
            {
                var recipes = _dbContext.Recipes.Where(n => (n.Title.ToLower().Equals(q) || n.Title.ToLower().Contains(q)) && n.Difficulty.Equals(difficulty)).ToList();
                return View(recipes);
            }
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
