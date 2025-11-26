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
                    Description = "A simple chocolate cake anyone can bake.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 30,
                    Type = "Cake",
                    CategoryId = 3,
                    Instructions =
                        "1. Preheat oven to 350°F (175°C).\n" +
                        "2. Whisk flour, sugar, cocoa, and baking powder.\n" +
                        "3. Add eggs, melted butter, milk, and vanilla.\n" +
                        "4. Pour into a greased pan.\n" +
                        "5. Bake 30 minutes or until a toothpick comes out clean.\n" +
                        "6. Let cool before slicing."
                },
                new Recipe
                {
                    ID = 2,
                    Title = "Classic Apple Pie",
                    Description = "A beginner-friendly apple pie with a simple filling.",
                    Difficulty = "Medium",
                    PrepMinutes = 20,
                    BakeMinutes = 40,
                    Type = "Pie",
                    CategoryId = 2,
                    Instructions =
                        "1. Preheat oven to 375°F (190°C).\n" +
                        "2. Mix sliced apples with sugar and cinnamon.\n" +
                        "3. Place mixture into pie crust.\n" +
                        "4. Add top crust and cut small slits.\n" +
                        "5. Bake 40 minutes or until crust is golden.\n" +
                        "6. Cool 10 minutes before serving."
                },
                new Recipe
                {
                    ID = 3,
                    Title = "Easy Pumpkin Bread",
                    Description = "A soft, cozy pumpkin loaf made in one bowl.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 50,
                    Type = "Bread",
                    CategoryId = 2,
                    Instructions =
                        "1. Preheat oven to 350°F (175°C).\n" +
                        "2. Stir flour, sugar, cinnamon, and baking powder.\n" +
                        "3. Add eggs, melted butter, milk, and pumpkin.\n" +
                        "4. Pour into a greased loaf pan.\n" +
                        "5. Bake 50 minutes or until set.\n" +
                        "6. Cool before slicing."
                },
                new Recipe
                {
                    ID = 4,
                    Title = "Strawberry Shortcake Cups",
                    Description = "Light and simple layered strawberry dessert.",
                    Difficulty = "Easy",
                    PrepMinutes = 10,
                    BakeMinutes = 0,
                    Type = "Dessert",
                    CategoryId = 1,
                    Instructions =
                        "1. Slice strawberries and mix with a little sugar.\n" +
                        "2. Crumble shortcake or vanilla cake.\n" +
                        "3. Layer cake, berries, and whipped cream in cups.\n" +
                        "4. Repeat layers.\n" +
                        "5. Chill for 10 minutes and serve."
                },
                new Recipe
                {
                    ID = 5,
                    Title = "Lemon Bars",
                    Description = "Simple lemon bars with a buttery crust.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 25,
                    Type = "Dessert",
                    CategoryId = 4,
                    Instructions =
                        "1. Preheat oven to 350°F (175°C).\n" +
                        "2. Mix crust: flour, sugar, melted butter.\n" +
                        "3. Press crust into a pan and bake 10 minutes.\n" +
                        "4. Whisk lemon juice, sugar, eggs, and flour.\n" +
                        "5. Pour over warm crust.\n" +
                        "6. Bake 15 more minutes and cool before cutting."
                },
                new Recipe
                {
                    ID = 6,
                    Title = "Simple Cinnamon Rolls",
                    Description = "Soft cinnamon rolls made with basic dough.",
                    Difficulty = "Medium",
                    PrepMinutes = 25,
                    BakeMinutes = 20,
                    Type = "Bread",
                    CategoryId = 4,
                    Instructions =
                        "1. Mix flour, yeast, sugar, milk, and butter into soft dough.\n" +
                        "2. Roll the dough into a rectangle.\n" +
                        "3. Spread butter, cinnamon, and sugar.\n" +
                        "4. Roll up and slice into spirals.\n" +
                        "5. Bake 20 minutes at 350°F.\n" +
                        "6. Add icing if desired."
                },
                new Recipe
                {
                    ID = 7,
                    Title = "Cinnamon Sugar Cookies",
                    Description = "Soft, chewy cookies rolled in cinnamon sugar.",
                    Difficulty = "Easy",
                    PrepMinutes = 15,
                    BakeMinutes = 12,
                    Type = "Cookies",
                    CategoryId = 2,
                    Instructions =
                        "1. Cream butter and sugar.\n" +
                        "2. Add eggs and vanilla.\n" +
                        "3. Stir in flour, baking powder, and cinnamon.\n" +
                        "4. Roll dough into balls.\n" +
                        "5. Coat in cinnamon sugar.\n" +
                        "6. Bake 12 minutes at 350°F."
                },
                new Recipe
                {
                    ID = 8,
                    Title = "Soft Dinner Rolls",
                    Description = "Beginner-friendly yeast rolls for any holiday.",
                    Difficulty = "Medium",
                    PrepMinutes = 20,
                    BakeMinutes = 18,
                    Type = "Bread",
                    CategoryId = 3,
                    Instructions =
                        "1. Combine flour, yeast, milk, sugar, and butter.\n" +
                        "2. Knead 5 minutes.\n" +
                        "3. Let rise 1 hour.\n" +
                        "4. Shape into rolls.\n" +
                        "5. Bake 18 minutes at 350°F.\n" +
                        "6. Brush with melted butter."
                },
                new Recipe
                {
                    ID = 9,
                    Title = "Banana Bread",
                    Description = "A simple, moist banana bread anyone can make.",
                    Difficulty = "Easy",
                    PrepMinutes = 10,
                    BakeMinutes = 50,
                    Type = "Bread",
                    CategoryId = 5,
                    Instructions =
                        "1. Mash ripe bananas.\n" +
                        "2. Stir in sugar, eggs, and melted butter.\n" +
                        "3. Add flour and baking powder.\n" +
                        "4. Pour into a loaf pan.\n" +
                        "5. Bake 50 minutes at 350°F.\n" +
                        "6. Cool completely before slicing."
                },
                new Recipe
                {
                    ID = 10,
                    Title = "No-Bake Chocolate Tart",
                    Description = "An easy no-bake tart with a basic ganache filling.",
                    Difficulty = "Medium",
                    PrepMinutes = 20,
                    BakeMinutes = 0,
                    Type = "Dessert",
                    CategoryId = 3,
                    Instructions =
                        "1. Mix graham crumbs and melted butter.\n" +
                        "2. Press into a tart pan and chill.\n" +
                        "3. Heat cream until warm.\n" +
                        "4. Stir in chocolate chips until smooth.\n" +
                        "5. Pour into crust.\n" +
                        "6. Chill 1 hour before serving."
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
