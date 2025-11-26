using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServerFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBasicBakingRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Whisk together the batter, pour into a pan, and bake until a toothpick comes out clean.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Fill a basic pie crust with spiced apples, add caramel, and bake until golden and bubbly.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Stir a simple pumpkin batter together in one bowl and bake until the loaf is set in the center.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Layer bite-size cake pieces, sweet berries, and whipped cream into small serving cups.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Press a simple crust into a pan, pour on the lemon filling, and bake until just set.", "Dessert" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Mix a soft dough, roll it with cinnamon sugar, slice, and bake until fluffy and golden.", "Bread" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 7,
                column: "Description",
                value: "Cream butter and sugar, roll the dough into balls, coat in cinnamon sugar, and bake.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Let a simple yeast dough rise, shape into rolls, and bake until lightly browned.", "Bread" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "Mash ripe bananas, stir in the batter, and bake until the loaf is browned and fragrant.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Press crumbs into a tart pan, chill, then fill with a simple chocolate ganache and let it set.", "Dessert" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "A rich and moist chocolate cake.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Classic fall apple pie with a caramel twist.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Soft and spiced pumpkin quick bread.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 4,
                column: "Description",
                value: "Layered strawberries, cream, and cake in a cup.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Tangy lemon bars with a buttery shortbread crust.", "Bars" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Soft cinnamon rolls with a sweet glaze.", "Rolls" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 7,
                column: "Description",
                value: "Sweet and simple fall cookies.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Soft, buttery dinner rolls perfect for holidays.", "Rolls" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 9,
                column: "Description",
                value: "Moist banana bread with a tender crumb.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Type" },
                values: new object[] { "No-bake chocolate tart with a graham cracker crust.", "Tart" });
        }
    }
}
