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
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Difficulty { get; set; } = null!;
        public int PrepMinutes { get; set; }
        public int BakeMinutes { get; set; }
        public string Type { get; set; } = null!;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}