using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Migrations
{
    public partial class UpdateManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "Id", "IngredientId", "RecipeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "Id", "IngredientId", "RecipeId" },
                values: new object[] { 2, 2, 1 });
        }
    }
}
