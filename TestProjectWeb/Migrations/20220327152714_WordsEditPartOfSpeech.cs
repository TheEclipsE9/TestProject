using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectWeb.Migrations
{
    public partial class WordsEditPartOfSpeech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartOfSpeech",
                table: "Words",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PartOfSpeech",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
