using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectWeb.Migrations
{
    public partial class dbQuizUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Quizzes");
        }
    }
}
