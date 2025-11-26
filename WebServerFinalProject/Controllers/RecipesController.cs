using Microsoft.AspNetCore.Mvc;
using WebServerFinalProject.Models;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WebServerFinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace WebServerFinalProject.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RecipesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult> submitForm(FormData formData)
        {
            return RedirectToAction("Index", new { q = formData.title });
        }

        public async Task<ActionResult<List<Recipe>>> Index(string? q, string? difficulty)
        {
            // Start with all recipes as a queryable
            var recipesQuery = _dbContext.Recipes.AsQueryable();

            // Filter by search term if provided
            if (!q.IsNullOrEmpty())
            {
                var lowerQ = q.ToLower();
                recipesQuery = recipesQuery.Where(n =>
                    n.Title.ToLower().Contains(lowerQ));
            }

            // Filter by difficulty if provided
            if (!difficulty.IsNullOrEmpty())
            {
                recipesQuery = recipesQuery.Where(n => n.Difficulty == difficulty);
            }

            // Execute query
            var recipes = recipesQuery.ToList();

            return View(recipes);
        }

        // /Recipes/Season
        public IActionResult Season(string? category)
        {
            ViewBag.SelectedSeason = category;

            if (!string.IsNullOrEmpty(category))
            {
                var seasonedRecipes = _dbContext.Recipes
                    .Join(_dbContext.Categories,
                        r => r.CategoryId,
                        c => c.CategoryId,
                        (r, c) => new { Recipe = r, CategoryName = c.Name })
                    .Where(rc => rc.CategoryName == category)
                    .ToList();

                List<Recipe> recipes = seasonedRecipes
                    .Select(item => item.Recipe)
                    .ToList();

                return View(recipes);
            }

            return View(new List<Recipe>());
        }

        // /Recipes/Type
        public IActionResult Type(string? type)
        {
            ViewBag.SelectedType = type;

            if (!type.IsNullOrEmpty())
            {
                var typedRecipes = _dbContext.Recipes
                    .Where(r => r.Type == type)
                    .ToList();

                return View(typedRecipes);
            }

            // When no type is selected yet, just return an empty list
            return View(new List<Recipe>());
        }

        // /Recipes/Details
        public IActionResult Details(int id)
        {
            var recipe = _dbContext.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.Category)
                .FirstOrDefault(r => r.ID == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }
    }
}
