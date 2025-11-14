using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServerFinalProject.Data;
using WebServerFinalProject.Models;

namespace WebServerFinalProject.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipesAsync(string? searchQuery, string? difficulty)
        {
            var query = _context.Recipes.Include(r => r.Category).AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(r => r.Title.Contains(searchQuery) || r.Description.Contains(searchQuery));
            }

            if (!string.IsNullOrEmpty(difficulty))
            {
                query = query.Where(r => r.Difficulty.Equals(difficulty));
            }

            return await query.ToListAsync();
        }

        public async Task<List<Recipe>> GetRecipesByCategoryAsync(string category)
        {
            return await _context.Recipes
                .Where(r => r.Category.Name.Equals(category))
                .Include(r => r.Category)
                .ToListAsync();
        }

        public async Task<List<Recipe>> GetRecipesByTypeAsync(string type)
        {
            return await _context.Recipes
                .Where(r => r.Type.Equals(type))
                .ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefaultAsync(r => r.ID == id);
        }
    }
}
