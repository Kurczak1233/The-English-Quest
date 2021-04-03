using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddWritingTaskAndQuizToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WritingQuizId",
                table: "PlacementTestTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WritingTask_TaskType",
                table: "PlacementTestTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WritingQuizzes",
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
                    table.PrimaryKey("PK_WritingQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WritingQuizzes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_WritingQuizId",
                table: "PlacementTestTasks",
                column: "WritingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingQuizzes_UserId",
                table: "WritingQuizzes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_WritingQuizzes_WritingQuizId",
                table: "PlacementTestTasks",
                column: "WritingQuizId",
                principalTable: "WritingQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_WritingQuizzes_WritingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropTable(
                name: "WritingQuizzes");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_WritingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "WritingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "WritingTask_TaskType",
                table: "PlacementTestTasks");
        }
    }
}
