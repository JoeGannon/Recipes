using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Instruction",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Salt" },
                    { 2, "Pepper" }
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "The Best Recipe", null, "Recipe 1" },
                    { 2, "Not Quite The Best Recipe", null, "Recipe 2" }
                });

            migrationBuilder.InsertData(
                table: "Instruction",
                columns: new[] { "Id", "Description", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Add cup of Salt", 1 },
                    { 2, "Add cup of pepper", 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "Id", "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction");

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instruction",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Instruction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
