using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectWeb.Migrations
{
    public partial class WordsAddCategoryPartOfSpeech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PartOfSpeech",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "PartOfSpeech",
                table: "Words");
        }
    }
}
