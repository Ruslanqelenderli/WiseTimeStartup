using Microsoft.EntityFrameworkCore.Migrations;

namespace WiseTime.Data.Migrations
{
    public partial class CommentReplyPostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "AnswerComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerComments_PostId",
                table: "AnswerComments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerComments_Posts_PostId",
                table: "AnswerComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerComments_Posts_PostId",
                table: "AnswerComments");

            migrationBuilder.DropIndex(
                name: "IX_AnswerComments_PostId",
                table: "AnswerComments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AnswerComments");
        }
    }
}
