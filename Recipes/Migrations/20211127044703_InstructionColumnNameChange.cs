using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Migrations
{
    public partial class InstructionColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Instruction");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Instruction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Instruction");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Instruction",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
