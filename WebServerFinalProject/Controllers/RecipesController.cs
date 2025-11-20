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
        //TODO: The Drop down resets everytime the page refreshes(JavaScript stuff :) )
        public IActionResult Season(string? category)
        {
            var seasonedRecipes = _dbContext.Recipes.Join(_dbContext.Categories, r => r.CategoryId, c => c.CategoryId, (r, c) => new { Recipe = r, CategoryName = c.Name })
                .Where(rc => rc.CategoryName == category)
                .ToList();
            List<Recipe> recipes = new List<Recipe>();
            foreach (var item in seasonedRecipes)
            {
                recipes.Add(item.Recipe);
            }
            return View(recipes);
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
