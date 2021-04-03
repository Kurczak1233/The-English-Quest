using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddReadingModelsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadingQuizId",
                table: "PlacementTestTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadingTask_TaskType",
                table: "PlacementTestTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReadingQuizes",
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
                    table.PrimaryKey("PK_ReadingQuizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingQuizes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_ReadingQuizId",
                table: "PlacementTestTasks",
                column: "ReadingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingQuizes_UserId",
                table: "ReadingQuizes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_ReadingQuizes_ReadingQuizId",
                table: "PlacementTestTasks",
                column: "ReadingQuizId",
                principalTable: "ReadingQuizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_ReadingQuizes_ReadingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropTable(
                name: "ReadingQuizes");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_ReadingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "ReadingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "ReadingTask_TaskType",
                table: "PlacementTestTasks");
        }
    }
}
