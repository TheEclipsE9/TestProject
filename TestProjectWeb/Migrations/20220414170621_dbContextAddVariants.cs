using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectWeb.Migrations
{
    public partial class dbContextAddVariants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variant_Questions_QuestionId",
                table: "Variant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variant",
                table: "Variant");

            migrationBuilder.RenameTable(
                name: "Variant",
                newName: "Variants");

            migrationBuilder.RenameIndex(
                name: "IX_Variant_QuestionId",
                table: "Variants",
                newName: "IX_Variants_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variants",
                table: "Variants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Questions_QuestionId",
                table: "Variants",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Questions_QuestionId",
                table: "Variants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variants",
                table: "Variants");

            migrationBuilder.RenameTable(
                name: "Variants",
                newName: "Variant");

            migrationBuilder.RenameIndex(
                name: "IX_Variants_QuestionId",
                table: "Variant",
                newName: "IX_Variant_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variant",
                table: "Variant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Variant_Questions_QuestionId",
                table: "Variant",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
