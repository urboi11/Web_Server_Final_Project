using Microsoft.EntityFrameworkCore;
using WebServerFinalProject.Models;  // Include the namespace for your models

namespace WebServerFinalProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSets for each model (table in your database)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        // Constructor that takes DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Configure relationships using Fluent API in OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Recipe and Ingredient through RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId }); // Composite Key for RecipeIngredient

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            // Configure one-to-many relationship between Recipe and Category
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);  // You can change delete behavior if needed

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Spring" },
                new Category { CategoryId = 2, Name = "Fall" },
                new Category { CategoryId = 3, Name = "Holiday" },
                new Category { CategoryId = 4, Name = "Summer" },
                new Category { CategoryId = 5, Name = "Winter" }
            );

            // Seed Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Flour" },
                new Ingredient { IngredientId = 2, Name = "Sugar" },
                new Ingredient { IngredientId = 3, Name = "Eggs" },
                new Ingredient { IngredientId = 4, Name = "Butter" },
                new Ingredient { IngredientId = 5, Name = "Vanilla Extract" },
                new Ingredient { IngredientId = 6, Name = "Baking Powder" },
                new Ingredient { IngredientId = 7, Name = "Cinnamon" },
                new Ingredient { IngredientId = 8, Name = "Strawberries" },
                new Ingredient { IngredientId = 9, Name = "Spinach" },
                new Ingredient { IngredientId = 10, Name = "Lemons" },
                new Ingredient { IngredientId = 11, Name = "Chicken Breast" },
                new Ingredient { IngredientId = 12, Name = "Bread Rolls" },
                new Ingredient { IngredientId = 13, Name = "Ground Beef" },
                new Ingredient { IngredientId = 14, Name = "Bananas" },
                new Ingredient { IngredientId = 15, Name = "Milk" },
            );

            // Seed Recipes
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { ID = 1, Title = "Chocolate Cake", Description = "A rich and moist chocolate cake.", Difficulty = "Medium", PrepMinutes = 15, BakeMinutes = 30, Type = "Dessert", CategoryId = 3 },
                new Recipe { ID = 2, Title = "Apple Pie", Description = "Classic American apple pie.", Difficulty = "Medium", PrepMinutes = 20, BakeMinutes = 40, Type = "Dessert", CategoryId = 2 },
                new Recipe { ID = 3, Title = "Pumpkin Soup", Description = "A hearty fall favorite.", Difficulty = "Easy", PrepMinutes = 10, BakeMinutes = 25, Type = "Soup", CategoryId = 1 },
                new Recipe { ID = 4, Title = "Strawberry Spinach Salad", Description = "A fresh spring salad with strawberries.", Difficulty = "Easy", PrepMinutes = 10, BakeMinutes = 0, Type = "Salad", CategoryId = 4 },
                new Recipe { ID = 5, Title = "Homemade Lemonade", Description = "Refreshing summer lemonade.", Difficulty = "Easy", PrepMinutes = 5, BakeMinutes = 0, Type = "Beverage", CategoryId = 5 },
                new Recipe { ID = 6, Title = "Grilled Chicken Sandwich", Description = "Juicy chicken sandwich perfect for summer.", Difficulty = "Medium", PrepMinutes = 15, BakeMinutes = 10, Type = "Main", CategoryId = 6 },
                new Recipe { ID = 7, Title = "Cinnamon Sugar Cookies", Description = "Sweet and simple fall cookies.", Difficulty = "Easy", PrepMinutes = 15, BakeMinutes = 12, Type = "Cookies", CategoryId = 7 },
                new Recipe { ID = 8, Title = "Roast Turkey", Description = "Traditional holiday roast turkey.", Difficulty = "Hard", PrepMinutes = 30, BakeMinutes = 180, Type = "Main", CategoryId = 8 },
                new Recipe { ID = 9, Title = "Banana Bread", Description = "Moist winter banana bread.", Difficulty = "Easy", PrepMinutes = 15, BakeMinutes = 50, Type = "Bread", CategoryId = 9 },
                new Recipe { ID = 10, Title = "Vegetable Stir Fry", Description = "Quick and healthy vegetable stir fry.", Difficulty = "Easy", PrepMinutes = 10, BakeMinutes = 15, Type = "Main", CategoryId = 10 }
            );

            // Seed RecipeIngredients (join table)
            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient { RecipeId = 1, IngredientId = 1, Quantity = 2, Unit = "cups" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 2, Quantity = 1.5, Unit = "cups" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 3, Quantity = 3, Unit = "eggs" },
                new RecipeIngredient { RecipeId = 1, IngredientId = 4, Quantity = 0.5, Unit = "cups" },

                new RecipeIngredient { RecipeId = 2, IngredientId = 1, Quantity = 3, Unit = "cups" },
                new RecipeIngredient { RecipeId = 2, IngredientId = 2, Quantity = 1, Unit = "cup" },
                new RecipeIngredient { RecipeId = 2, IngredientId = 3, Quantity = 2, Unit = "eggs" },
                new RecipeIngredient { RecipeId = 2, IngredientId = 4, Quantity = 0.75, Unit = "cups" },

                new RecipeIngredient { RecipeId = 3, IngredientId = 1, Quantity = 1, Unit = "cup" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 2, Quantity = 0.5, Unit = "cup" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 3, Quantity = 1, Unit = "cup" },
                new RecipeIngredient { RecipeId = 3, IngredientId = 7, Quantity = 1, Unit = "tsp" }
            );
        }
    }
}
