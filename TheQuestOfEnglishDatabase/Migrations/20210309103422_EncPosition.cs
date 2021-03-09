using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class EncPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncouragementPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceToCollapse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HtmlIdName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncouragementPositions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncouragementPositions");
        }
    }
}
