using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Migrations
{
    public partial class SeedMoreDataAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Butter" },
                    { 4, "Baking Soda" },
                    { 5, "Sugar" },
                    { 6, "Milk" },
                    { 7, "Eggs" },
                    { 8, "Garlic" },
                    { 9, "Hot Sauce" }
                });

            migrationBuilder.InsertData(
                table: "Instruction",
                columns: new[] { "Id", "Description", "RecipeId" },
                values: new object[,]
                {
                    { 19, "Drain on paper towels.", 2 },
                    { 18, "Heat the oil in a deep skillet over medium-high heat. Add the coated fish but don’t crowd the pan. Cook for 2 minutes or until the bottoms are golden brown. Carefully flip the pieces over with tongs, and cook another 2 minutes or until the other side is golden brown.", 2 },
                    { 17, "Coat the fish in the following order: Egg, flour mix, egg again and panko then then flour.", 2 },
                    { 16, "In a separate bowl, mix flour, salt, black pepper, and paprika.", 2 },
                    { 14, "In a small bowl, beat the egg for coating.", 2 },
                    { 13, "Cut the fish into 1×3 inch slices.", 2 },
                    { 12, "Bake for 20-25 mins or until golden brown.", 1 },
                    { 11, "Pre-heat oven to 350°F", 1 },
                    { 8, "Divide dough into 24 equal parts and shape it into a ball.", 1 },
                    { 9, "Dip dough into the breadcrumbs and arrange in a pan.", 1 },
                    { 20, "Top it off with Kewpie mayo, Okonomi Sauce and Bonito flakes.", 2 },
                    { 7, "Transfer to a light greased bowl and let it rise for 1 hour or until the size is doubled.", 1 },
                    { 6, "Mix until all ingredients are incorporated and form a smooth dough.", 1 },
                    { 5, "Add Sugar, butter, and egg", 1 },
                    { 4, "Mix flour, salt, and yeast in a bowl or mixer", 1 },
                    { 3, "Mix warm milk, yeast, 2 tsp sugar and let is sit for 10-15 mins until foamy", 1 },
                    { 10, "Let it rise for another 20 mins.", 1 },
                    { 21, "Serve and Enjoy!", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
