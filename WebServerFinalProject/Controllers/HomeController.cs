using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebServerFinalProject.Data;
using WebServerFinalProject.Models;
using System.Linq;

namespace WebServerFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

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

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult AboutHobby()
        {
            return View();
        }

        // ================================
        // DATABASE INFO PAGE
        // ================================
        public IActionResult DatabaseInfo()
        {
            var model = new DatabaseInfoViewModel
            {
                RecipeCount = _dbContext.Recipes.Count(),
                IngredientCount = _dbContext.Ingredients.Count(),
                CategoryCount = _dbContext.Categories.Count(),
                RecipeIngredientCount = _dbContext.RecipeIngredients.Count(),

                Categories = _dbContext.Categories
                    .Select(c => new CategorySummary
                    {
                        Name = c.Name,
                        RecipeCount = _dbContext.Recipes.Count(r => r.CategoryId == c.CategoryId)
                    })
                    .ToList(),

                Types = _dbContext.Recipes
                    .GroupBy(r => r.Type)
                    .Select(g => new TypeSummary
                    {
                        Type = g.Key,
                        RecipeCount = g.Count()
                    })
                    .ToList(),

                Difficulties = _dbContext.Recipes
                    .GroupBy(r => r.Difficulty)
                    .Select(g => new DifficultySummary
                    {
                        Difficulty = g.Key,
                        RecipeCount = g.Count()
                    })
                    .ToList()
            };

            return View(model);
        }
    }
}
