using WebServerFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServerFinalProject.Service
{
    public interface IRecipeIngredientService
    {
        Task<List<RecipeIngredient>> GetIngredientsForRecipeAsync(int recipeId);
        Task AddIngredientToRecipeAsync(RecipeIngredient recipeIngredient);
        Task RemoveIngredientFromRecipeAsync(int recipeId, int ingredientId);
        Task UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient);
    }
}
