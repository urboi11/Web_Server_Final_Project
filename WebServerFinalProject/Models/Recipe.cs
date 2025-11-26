using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebServerFinalProject.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int PrepMinutes { get; set; }
        public int BakeMinutes { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // NEW – full steps for the recipe
        public string? Instructions { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}