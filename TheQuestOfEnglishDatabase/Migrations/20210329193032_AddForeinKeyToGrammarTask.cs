using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddForeinKeyToGrammarTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_Quizzes_GrammarQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_Quizzes_GrammarQuizId",
                table: "PlacementTestTasks",
                column: "GrammarQuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_Quizzes_GrammarQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_Quizzes_GrammarQuizId",
                table: "PlacementTestTasks",
                column: "GrammarQuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
