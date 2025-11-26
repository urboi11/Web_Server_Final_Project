using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebServerFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class BakingOnlySeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 4, "Summer" },
                    { 5, "Winter" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name" },
                values: new object[,]
                {
                    { 8, "Strawberries" },
                    { 9, "Whipped Cream" },
                    { 10, "Lemons" },
                    { 11, "Yeast" },
                    { 12, "Brown Sugar" },
                    { 13, "Cream Cheese" },
                    { 14, "Bananas" },
                    { 15, "Milk" },
                    { 16, "Chocolate Chips" },
                    { 17, "Heavy Cream" },
                    { 18, "Graham Cracker Crumbs" }
                });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 1 },
                column: "Unit",
                value: "pcs");

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "cups" });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 3 },
                column: "Quantity",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 2.0, "pcs" });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 3 },
                column: "Quantity",
                value: 2.0);

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 5, 1, 2.0, "tsp" },
                    { 7, 2, 1.0, "tsp" },
                    { 6, 3, 2.0, "tsp" }
                });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Type",
                value: "Cake");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Title", "Type" },
                values: new object[] { "Classic fall apple pie with a caramel twist.", "Caramel Apple Pie", "Pie" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "BakeMinutes", "CategoryId", "Description", "PrepMinutes", "Title", "Type" },
                values: new object[] { 50, 2, "Soft and spiced pumpkin quick bread.", 15, "Pumpkin Bread", "Bread" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "ID", "BakeMinutes", "CategoryId", "Description", "Difficulty", "PrepMinutes", "Title", "Type" },
                values: new object[,]
                {
                    { 4, 0, 1, "Layered strawberries, cream, and cake in a cup.", "Easy", 15, "Strawberry Shortcake Cups", "Dessert" },
                    { 7, 12, 2, "Sweet and simple fall cookies.", "Easy", 15, "Cinnamon Sugar Cookies", "Cookies" },
                    { 8, 18, 3, "Soft, buttery dinner rolls perfect for holidays.", "Medium", 20, "Holiday Dinner Rolls", "Rolls" },
                    { 10, 0, 3, "No-bake chocolate tart with a graham cracker crust.", "Hard", 20, "Chocolate Ganache Tart", "Tart" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 12, 2, 0.5, "cup" },
                    { 1, 4, 1.0, "cup" },
                    { 2, 4, 0.5, "cup" },
                    { 8, 4, 1.5, "cups" },
                    { 9, 4, 1.0, "cup" },
                    { 1, 7, 2.0, "cups" },
                    { 2, 7, 1.0, "cup" },
                    { 3, 7, 2.0, "pcs" },
                    { 4, 7, 0.5, "cup" },
                    { 7, 7, 1.0, "tsp" },
                    { 1, 8, 3.0, "cups" },
                    { 2, 8, 0.25, "cup" },
                    { 4, 8, 0.25, "cup" },
                    { 11, 8, 2.0, "tsp" },
                    { 15, 8, 1.0, "cup" },
                    { 16, 10, 2.0, "cups" },
                    { 17, 10, 1.0, "cup" },
                    { 18, 10, 1.5, "cups" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "ID", "BakeMinutes", "CategoryId", "Description", "Difficulty", "PrepMinutes", "Title", "Type" },
                values: new object[,]
                {
                    { 5, 25, 4, "Tangy lemon bars with a buttery shortbread crust.", "Easy", 15, "Lemon Bars", "Bars" },
                    { 6, 20, 4, "Soft cinnamon rolls with a sweet glaze.", "Medium", 25, "Cinnamon Rolls", "Rolls" },
                    { 9, 50, 5, "Moist banana bread with a tender crumb.", "Easy", 15, "Banana Bread", "Bread" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, 5, 1.5, "cups" },
                    { 2, 5, 1.0, "cup" },
                    { 4, 5, 0.5, "cup" },
                    { 10, 5, 3.0, "pcs" },
                    { 1, 6, 3.0, "cups" },
                    { 7, 6, 2.0, "tsp" },
                    { 11, 6, 2.0, "tsp" },
                    { 12, 6, 0.5, "cup" },
                    { 15, 6, 1.0, "cup" },
                    { 1, 9, 2.0, "cups" },
                    { 2, 9, 1.0, "cup" },
                    { 3, 9, 2.0, "pcs" },
                    { 6, 9, 1.0, "tsp" },
                    { 14, 9, 3.0, "pcs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 15, 8 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 16, 10 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 17, 10 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 18, 10 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 1 },
                column: "Unit",
                value: "eggs");

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1.0, "cup" });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 3 },
                column: "Quantity",
                value: 0.5);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Quantity", "Unit" },
                values: new object[] { 1.0, "cup" });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 7, 3 },
                column: "Quantity",
                value: 1.0);

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Quantity", "Unit" },
                values: new object[] { 3, 2, 2.0, "eggs" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Type",
                value: "Dessert");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Title", "Type" },
                values: new object[] { "Classic American apple pie.", "Apple Pie", "Dessert" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "BakeMinutes", "CategoryId", "Description", "PrepMinutes", "Title", "Type" },
                values: new object[] { 25, 1, "A hearty fall favorite.", 10, "Pumpkin Soup", "Soup" });
        }
    }
}
