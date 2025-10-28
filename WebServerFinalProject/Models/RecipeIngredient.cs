using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebServerFinalProject.Models
{
        public class RecipeIngredient
    {
        public int RecipeId { get; set; }  // Foreign Key to Recipe
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }  // Foreign Key to Ingredient
        public Ingredient Ingredient { get; set; }

        public double Quantity { get; set; }
        public string Unit { get; set; }  // e.g., grams, cups, etc.
    }

}