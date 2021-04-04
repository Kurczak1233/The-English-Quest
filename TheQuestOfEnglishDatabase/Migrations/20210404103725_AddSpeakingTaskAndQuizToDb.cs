using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddSpeakingTaskAndQuizToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeakingQuizId",
                table: "PlacementTestTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpeakingTask_TaskType",
                table: "PlacementTestTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpeakingQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingQuizzes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_SpeakingQuizId",
                table: "PlacementTestTasks",
                column: "SpeakingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingQuizzes_UserId",
                table: "SpeakingQuizzes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_SpeakingQuizzes_SpeakingQuizId",
                table: "PlacementTestTasks",
                column: "SpeakingQuizId",
                principalTable: "SpeakingQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_SpeakingQuizzes_SpeakingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropTable(
                name: "SpeakingQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_SpeakingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "SpeakingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "SpeakingTask_TaskType",
                table: "PlacementTestTasks");
        }
    }
}
