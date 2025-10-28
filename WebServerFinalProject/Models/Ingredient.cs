using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServerFinalProject.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }  // Primary Key
        public string Name { get; set; }

        // Navigation properties
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}