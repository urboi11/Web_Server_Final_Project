using Microsoft.EntityFrameworkCore;
using WebServerFinalProject.Models;  // Include the namespace for your models

namespace WebServerFinalProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSets for each model
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

            // Seed Ingredients (baking-only)
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Flour" },
                new Ingredient { IngredientId = 2, Name = "Sugar" },
                new Ingredient { IngredientId = 3, Name = "Eggs" },
                new Ingredient { IngredientId = 4, Name = "Butter" },
                new Ingredient { IngredientId = 5, Name = "Vanilla Extract" },
                new Ingredient { IngredientId = 6, Name = "Baking Powder" },
                new Ingredient { IngredientId = 7, Name = "Cinnamon" },
                new Ingredient { IngredientId = 8, Name = "Strawberries" },
                new Ingredient { IngredientId = 9, Name = "Whipped Cream" },
                new Ingredient { IngredientId = 10, Name = "Lemons" },
                new Ingredient { IngredientId = 11, Name = "Yeast" },
                new Ingredient { IngredientId = 12, Name = "Brown Sugar" },
                new Ingredient { IngredientId = 13, Name = "Cream Cheese" },
                new Ingredient { IngredientId = 14, Name = "Bananas" },
                new Ingredient { IngredientId = 15, Name = "Milk" },
                new Ingredient { IngredientId = 16, Name = "Chocolate Chips" },
                new Ingredient { IngredientId = 17, Name = "Heavy Cream" },
                new Ingredient { IngredientId = 18, Name = "Graham Cracker Crumbs" }
            );

            // Seed Recipes
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    ID = 1,
                    Title = "Chocolate Cake",
                    Description = "Whisk together the batter, pour into a pan, and bake until a toothpick comes out clean.",
                    Difficulty = "Medium",
                    PrepMinutes = 15,
                    BakeMinutes = 30,
                    Type = "Cake",
                    CategoryId = 3 // Holiday
                },
                new Recipe
                {
                    ID = 2,
                    Title = "Caramel Apple Pie",
                    Description = "Fill a basic pie crust with spiced apples, add caramel, and bake until golden and bubbly.",
                    Difficulty = "Medium",
                    PrepMinutes = 20,
                    BakeMinutes = 40,
                    Type = "Pie",
                    CategoryId = 2 // Fall
                },
                new Recipe
                {
                    ID = 3,
                    Title = "Pumpkin Bread",
                    Description = "Stir a simple pumpkin batter together in one bowl and bake until the loaf is set in the center.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 50,
                    Type = "Bread",
                    CategoryId = 2 // Fall
                },
                new Recipe
                {
                    ID = 4,
                    Title = "Strawberry Shortcake Cups",
                    Description = "Layer bite-size cake pieces, sweet berries, and whipped cream into small serving cups.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 0,
                    Type = "Dessert",
                    CategoryId = 1 // Spring
                },
                new Recipe
                {
                    ID = 5,
                    Title = "Lemon Bars",
                    Description = "Press a simple crust into a pan, pour on the lemon filling, and bake until just set.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 25,
                    Type = "Dessert",
                    CategoryId = 4 // Summer
                },
                new Recipe
                {
                    ID = 6,
                    Title = "Cinnamon Rolls",
                    Description = "Mix a soft dough, roll it with cinnamon sugar, slice, and bake until fluffy and golden.",
                    Difficulty = "Medium",
                    PrepMinutes = 25,
                    BakeMinutes = 20,
                    Type = "Bread",
                    CategoryId = 4 // Summer
                },
                new Recipe
                {
                    ID = 7,
                    Title = "Cinnamon Sugar Cookies",
                    Description = "Cream butter and sugar, roll the dough into balls, coat in cinnamon sugar, and bake.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 12,
                    Type = "Cookies",
                    CategoryId = 2 // Fall
                },
                new Recipe
                {
                    ID = 8,
                    Title = "Holiday Dinner Rolls",
                    Description = "Let a simple yeast dough rise, shape into rolls, and bake until lightly browned.",
                    Difficulty = "Medium",
                    PrepMinutes = 20,
                    BakeMinutes = 18,
                    Type = "Bread",
                    CategoryId = 3 // Holiday
                },
                new Recipe
                {
                    ID = 9,
                    Title = "Banana Bread",
                    Description = "Mash ripe bananas, stir in the batter, and bake until the loaf is browned and fragrant.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 50,
                    Type = "Bread",
                    CategoryId = 5 // Winter
                },
                new Recipe
                {
                    ID = 10,
                    Title = "Chocolate Ganache Tart",
                    Description = "Press crumbs into a tart pan, chill, then fill with a simple chocolate ganache and let it set.",
                    Difficulty = "Hard",
                    PrepMinutes = 20,
                    BakeMinutes = 0,
                    Type = "Dessert",
                    CategoryId = 3 // Holiday
                }
            );


            // Seed RecipeIngredients (join table, all baking-focused)
            modelBuilder.Entity<RecipeIngredient>().HasData(

                // 1. Chocolate Cake
                new RecipeIngredient { RecipeId = 1, IngredientId = 1, Quantity = 2, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 1, IngredientId = 2, Quantity = 1.5, Unit = "cups" }, // Sugar
                new RecipeIngredient { RecipeId = 1, IngredientId = 3, Quantity = 3, Unit = "pcs" },    // Eggs
                new RecipeIngredient { RecipeId = 1, IngredientId = 4, Quantity = 0.5, Unit = "cups" }, // Butter
                new RecipeIngredient { RecipeId = 1, IngredientId = 5, Quantity = 2, Unit = "tsp" },    // Vanilla

                // 2. Caramel Apple Pie
                new RecipeIngredient { RecipeId = 2, IngredientId = 1, Quantity = 3, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 2, IngredientId = 2, Quantity = 1, Unit = "cup" },    // Sugar
                new RecipeIngredient { RecipeId = 2, IngredientId = 12, Quantity = 0.5, Unit = "cup" }, // Brown Sugar
                new RecipeIngredient { RecipeId = 2, IngredientId = 4, Quantity = 0.75, Unit = "cups" },// Butter
                new RecipeIngredient { RecipeId = 2, IngredientId = 7, Quantity = 1, Unit = "tsp" },    // Cinnamon

                // 3. Pumpkin Bread
                new RecipeIngredient { RecipeId = 3, IngredientId = 1, Quantity = 2, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 3, IngredientId = 2, Quantity = 1, Unit = "cup" },    // Sugar
                new RecipeIngredient { RecipeId = 3, IngredientId = 3, Quantity = 2, Unit = "pcs" },    // Eggs
                new RecipeIngredient { RecipeId = 3, IngredientId = 7, Quantity = 2, Unit = "tsp" },    // Cinnamon
                new RecipeIngredient { RecipeId = 3, IngredientId = 6, Quantity = 2, Unit = "tsp" },    // Baking Powder

                // 4. Strawberry Shortcake Cups
                new RecipeIngredient { RecipeId = 4, IngredientId = 8, Quantity = 1.5, Unit = "cups" }, // Strawberries
                new RecipeIngredient { RecipeId = 4, IngredientId = 9, Quantity = 1, Unit = "cup" },    // Whipped Cream
                new RecipeIngredient { RecipeId = 4, IngredientId = 1, Quantity = 1, Unit = "cup" },    // Flour
                new RecipeIngredient { RecipeId = 4, IngredientId = 2, Quantity = 0.5, Unit = "cup" },  // Sugar

                // 5. Lemon Bars
                new RecipeIngredient { RecipeId = 5, IngredientId = 10, Quantity = 3, Unit = "pcs" },   // Lemons
                new RecipeIngredient { RecipeId = 5, IngredientId = 2, Quantity = 1, Unit = "cup" },    // Sugar
                new RecipeIngredient { RecipeId = 5, IngredientId = 1, Quantity = 1.5, Unit = "cups" }, // Flour
                new RecipeIngredient { RecipeId = 5, IngredientId = 4, Quantity = 0.5, Unit = "cup" },  // Butter

                // 6. Cinnamon Rolls
                new RecipeIngredient { RecipeId = 6, IngredientId = 1, Quantity = 3, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 6, IngredientId = 11, Quantity = 2, Unit = "tsp" },   // Yeast
                new RecipeIngredient { RecipeId = 6, IngredientId = 12, Quantity = 0.5, Unit = "cup" }, // Brown Sugar
                new RecipeIngredient { RecipeId = 6, IngredientId = 7, Quantity = 2, Unit = "tsp" },    // Cinnamon
                new RecipeIngredient { RecipeId = 6, IngredientId = 15, Quantity = 1, Unit = "cup" },   // Milk

                // 7. Cinnamon Sugar Cookies
                new RecipeIngredient { RecipeId = 7, IngredientId = 1, Quantity = 2, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 7, IngredientId = 2, Quantity = 1, Unit = "cup" },    // Sugar
                new RecipeIngredient { RecipeId = 7, IngredientId = 4, Quantity = 0.5, Unit = "cup" },  // Butter
                new RecipeIngredient { RecipeId = 7, IngredientId = 7, Quantity = 1, Unit = "tsp" },    // Cinnamon
                new RecipeIngredient { RecipeId = 7, IngredientId = 3, Quantity = 2, Unit = "pcs" },    // Eggs

                // 8. Holiday Dinner Rolls
                new RecipeIngredient { RecipeId = 8, IngredientId = 1, Quantity = 3, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 8, IngredientId = 11, Quantity = 2, Unit = "tsp" },   // Yeast
                new RecipeIngredient { RecipeId = 8, IngredientId = 2, Quantity = 0.25, Unit = "cup" }, // Sugar
                new RecipeIngredient { RecipeId = 8, IngredientId = 4, Quantity = 0.25, Unit = "cup" }, // Butter
                new RecipeIngredient { RecipeId = 8, IngredientId = 15, Quantity = 1, Unit = "cup" },   // Milk

                // 9. Banana Bread
                new RecipeIngredient { RecipeId = 9, IngredientId = 14, Quantity = 3, Unit = "pcs" },   // Bananas
                new RecipeIngredient { RecipeId = 9, IngredientId = 1, Quantity = 2, Unit = "cups" },   // Flour
                new RecipeIngredient { RecipeId = 9, IngredientId = 2, Quantity = 1, Unit = "cup" },    // Sugar
                new RecipeIngredient { RecipeId = 9, IngredientId = 3, Quantity = 2, Unit = "pcs" },    // Eggs
                new RecipeIngredient { RecipeId = 9, IngredientId = 6, Quantity = 1, Unit = "tsp" },    // Baking Powder

                // 10. Chocolate Ganache Tart
                new RecipeIngredient { RecipeId = 10, IngredientId = 16, Quantity = 2, Unit = "cups" }, // Chocolate Chips
                new RecipeIngredient { RecipeId = 10, IngredientId = 17, Quantity = 1, Unit = "cup" },  // Heavy Cream
                new RecipeIngredient { RecipeId = 10, IngredientId = 18, Quantity = 1.5, Unit = "cups" } // Graham Cracker Crumbs
            );

        }
    }
}
