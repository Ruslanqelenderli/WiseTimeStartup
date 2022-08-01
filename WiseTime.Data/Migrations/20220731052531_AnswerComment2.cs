using Microsoft.EntityFrameworkCore.Migrations;

namespace WiseTime.Data.Migrations
{
    public partial class AnswerComment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AnswerComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AnswerComments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
