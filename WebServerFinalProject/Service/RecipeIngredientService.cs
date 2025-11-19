using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServerFinalProject.Data;
using WebServerFinalProject.Models;
using WebServerFinalProject.Service;

namespace WebServerFinalProject.Services
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public RecipeIngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all ingredients for a recipe
        public async Task<List<RecipeIngredient>> GetIngredientsForRecipeAsync(int recipeId)
        {
            return await _context.RecipeIngredients
                .Include(ri => ri.Ingredient)  // Include the Ingredient information
                .Where(ri => ri.RecipeId == recipeId)
                .ToListAsync();
        }

        // Add an ingredient to a recipe
        public async Task AddIngredientToRecipeAsync(RecipeIngredient recipeIngredient)
        {
            _context.RecipeIngredients.Add(recipeIngredient);
            await _context.SaveChangesAsync();
        }

        // Remove an ingredient from a recipe
        public async Task RemoveIngredientFromRecipeAsync(int recipeId, int ingredientId)
        {
            var recipeIngredient = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);
            if (recipeIngredient != null)
            {
                _context.RecipeIngredients.Remove(recipeIngredient);
                await _context.SaveChangesAsync();
            }
        }

        // Update a RecipeIngredient (for example, update quantity or unit)
        public async Task UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient)
        {
            _context.RecipeIngredients.Update(recipeIngredient);
            await _context.SaveChangesAsync();
        }
    }
}
