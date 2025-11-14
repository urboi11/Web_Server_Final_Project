using WebServerFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServerFinalProject.Services
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientByIdAsync(int id);
        Task AddIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(int id);
    }
}
