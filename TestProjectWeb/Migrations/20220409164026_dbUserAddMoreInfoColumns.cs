using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectWeb.Migrations
{
    public partial class dbUserAddMoreInfoColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "London");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "England");

            migrationBuilder.AddColumn<int>(
                name: "LanguageLevel",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LearningLanguage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "English");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "000000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageLevel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LearningLanguage",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");
        }
    }
}
