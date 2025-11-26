using System.Collections.Generic;

namespace WebServerFinalProject.Models
{
    public class DatabaseInfoViewModel
    {
        public int RecipeCount { get; set; }
        public int IngredientCount { get; set; }
        public int CategoryCount { get; set; }
        public int RecipeIngredientCount { get; set; }

        public List<CategorySummary> Categories { get; set; } = new();
        public List<TypeSummary> Types { get; set; } = new();
        public List<DifficultySummary> Difficulties { get; set; } = new();
    }

    public class CategorySummary
    {
        public string Name { get; set; } = "";
        public int RecipeCount { get; set; }
    }

    public class TypeSummary
    {
        public string Type { get; set; } = "";
        public int RecipeCount { get; set; }
    }

    public class DifficultySummary
    {
        public string Difficulty { get; set; } = "";
        public int RecipeCount { get; set; }
    }
}
