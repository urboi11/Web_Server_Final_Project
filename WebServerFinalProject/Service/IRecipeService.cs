using System.Collections.Generic;
using System.Threading.Tasks;
using WebServerFinalProject.Models;

namespace WebServerFinalProject.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllRecipesAsync(string? searchQuery, string? difficulty);
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<List<Recipe>> GetRecipesByCategoryAsync(string category);
        Task<List<Recipe>> GetRecipesByTypeAsync(string type);
    }
}
