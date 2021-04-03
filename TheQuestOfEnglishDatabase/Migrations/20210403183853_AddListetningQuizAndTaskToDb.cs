using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddListetningQuizAndTaskToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrammarTask_TaskType",
                table: "PlacementTestTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListeningQuizId",
                table: "PlacementTestTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListegningQuizes",
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
                    table.PrimaryKey("PK_ListegningQuizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListegningQuizes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_ListeningQuizId",
                table: "PlacementTestTasks",
                column: "ListeningQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_ListegningQuizes_UserId",
                table: "ListegningQuizes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_ListegningQuizes_ListeningQuizId",
                table: "PlacementTestTasks",
                column: "ListeningQuizId",
                principalTable: "ListegningQuizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_ListegningQuizes_ListeningQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropTable(
                name: "ListegningQuizes");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_ListeningQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "GrammarTask_TaskType",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "ListeningQuizId",
                table: "PlacementTestTasks");
        }
    }
}
