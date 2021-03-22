using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddPlacementTaskModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlacementTestTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionFirstPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionDecoratedPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSecondPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FourthAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementTestTasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacementTestTasks");
        }
    }
}
