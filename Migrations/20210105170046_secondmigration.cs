using Microsoft.EntityFrameworkCore.Migrations;

namespace quiz_backend.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer2",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer3",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer3",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Questions");
        }
    }
}
