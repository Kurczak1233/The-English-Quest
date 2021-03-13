using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class AddSecondPartOFQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Question2",
                table: "SampleTestQA",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question2",
                table: "SampleTestQA");
        }
    }
}
