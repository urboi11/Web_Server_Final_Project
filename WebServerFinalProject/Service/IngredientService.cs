using WebServerFinalProject.Models;
using WebServerFinalProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServerFinalProject.Services;

namespace WebServerFinalProject.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext _context;

        // Constructor that takes ApplicationDbContext as a dependency
        public IngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all ingredients from the database
        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        // Get a specific ingredient by ID
        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _context.Ingredients
                .FirstOrDefaultAsync(i => i.IngredientId == id);
        }

        // Add a new ingredient to the database
        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        // Update an existing ingredient
        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
        }

        // Delete an ingredient by ID
        public async Task DeleteIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
