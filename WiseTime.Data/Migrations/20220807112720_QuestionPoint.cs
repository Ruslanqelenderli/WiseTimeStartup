using Microsoft.EntityFrameworkCore.Migrations;

namespace WiseTime.Data.Migrations
{
    public partial class QuestionPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Point",
                table: "Questions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Questions");
        }
    }
}
