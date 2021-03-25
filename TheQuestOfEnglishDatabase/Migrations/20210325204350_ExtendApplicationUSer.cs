using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class ExtendApplicationUSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Description",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");
        }
    }
}
