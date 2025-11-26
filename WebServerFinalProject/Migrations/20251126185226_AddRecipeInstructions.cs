using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServerFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeInstructions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Difficulty", "Instructions" },
                values: new object[] { "A simple chocolate cake anyone can bake.", "Easy", "1. Preheat oven to 350°F (175°C).\n2. Whisk flour, sugar, cocoa, and baking powder.\n3. Add eggs, melted butter, milk, and vanilla.\n4. Pour into a greased pan.\n5. Bake 30 minutes or until a toothpick comes out clean.\n6. Let cool before slicing." });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Instructions", "Title" },
                values: new object[] { "A beginner-friendly apple pie with a simple filling.", "1. Preheat oven to 375°F (190°C).\n2. Mix sliced apples with sugar and cinnamon.\n3. Place mixture into pie crust.\n4. Add top crust and cut small slits.\n5. Bake 40 minutes or until crust is golden.\n6. Cool 10 minutes before serving.", "Classic Apple Pie" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Instructions", "Title" },
                values: new object[] { "A soft, cozy pumpkin loaf made in one bowl.", "1. Preheat oven to 350°F (175°C).\n2. Stir flour, sugar, cinnamon, and baking powder.\n3. Add eggs, melted butter, milk, and pumpkin.\n4. Pour into a greased loaf pan.\n5. Bake 50 minutes or until set.\n6. Cool before slicing.", "Easy Pumpkin Bread" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Instructions", "PrepMinutes" },
                values: new object[] { "Light and simple layered strawberry dessert.", "1. Slice strawberries and mix with a little sugar.\n2. Crumble shortcake or vanilla cake.\n3. Layer cake, berries, and whipped cream in cups.\n4. Repeat layers.\n5. Chill for 10 minutes and serve.", 10 });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "Simple lemon bars with a buttery crust.", "1. Preheat oven to 350°F (175°C).\n2. Mix crust: flour, sugar, melted butter.\n3. Press crust into a pan and bake 10 minutes.\n4. Whisk lemon juice, sugar, eggs, and flour.\n5. Pour over warm crust.\n6. Bake 15 more minutes and cool before cutting." });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Instructions", "Title" },
                values: new object[] { "Soft cinnamon rolls made with basic dough.", "1. Mix flour, yeast, sugar, milk, and butter into soft dough.\n2. Roll the dough into a rectangle.\n3. Spread butter, cinnamon, and sugar.\n4. Roll up and slice into spirals.\n5. Bake 20 minutes at 350°F.\n6. Add icing if desired.", "Simple Cinnamon Rolls" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "Soft, chewy cookies rolled in cinnamon sugar.", "1. Cream butter and sugar.\n2. Add eggs and vanilla.\n3. Stir in flour, baking powder, and cinnamon.\n4. Roll dough into balls.\n5. Coat in cinnamon sugar.\n6. Bake 12 minutes at 350°F." });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Instructions", "Title" },
                values: new object[] { "Beginner-friendly yeast rolls for any holiday.", "1. Combine flour, yeast, milk, sugar, and butter.\n2. Knead 5 minutes.\n3. Let rise 1 hour.\n4. Shape into rolls.\n5. Bake 18 minutes at 350°F.\n6. Brush with melted butter.", "Soft Dinner Rolls" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Instructions", "PrepMinutes" },
                values: new object[] { "A simple, moist banana bread anyone can make.", "1. Mash ripe bananas.\n2. Stir in sugar, eggs, and melted butter.\n3. Add flour and baking powder.\n4. Pour into a loaf pan.\n5. Bake 50 minutes at 350°F.\n6. Cool completely before slicing.", 10 });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Difficulty", "Instructions", "Title" },
                values: new object[] { "An easy no-bake tart with a basic ganache filling.", "Medium", "1. Mix graham crumbs and melted butter.\n2. Press into a tart pan and chill.\n3. Heat cream until warm.\n4. Stir in chocolate chips until smooth.\n5. Pour into crust.\n6. Chill 1 hour before serving.", "No-Bake Chocolate Tart" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Difficulty" },
                values: new object[] { "Whisk together the batter, pour into a pan, and bake until a toothpick comes out clean.", "Medium" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Fill a basic pie crust with spiced apples, add caramel, and bake until golden and bubbly.", "Caramel Apple Pie" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Stir a simple pumpkin batter together in one bowl and bake until the loaf is set in the center.", "Pumpkin Bread" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "PrepMinutes" },
                values: new object[] { "Layer bite-size cake pieces, sweet berries, and whipped cream into small serving cups.", 15 });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 5,
                column: "Description",
                value: "Press a simple crust into a pan, pour on the lemon filling, and bake until just set.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Mix a soft dough, roll it with cinnamon sugar, slice, and bake until fluffy and golden.", "Cinnamon Rolls" });

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
                columns: new[] { "Description", "Title" },
                values: new object[] { "Let a simple yeast dough rise, shape into rolls, and bake until lightly browned.", "Holiday Dinner Rolls" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "PrepMinutes" },
                values: new object[] { "Mash ripe bananas, stir in the batter, and bake until the loaf is browned and fragrant.", 15 });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Difficulty", "Title" },
                values: new object[] { "Press crumbs into a tart pan, chill, then fill with a simple chocolate ganache and let it set.", "Hard", "Chocolate Ganache Tart" });
        }
    }
}
