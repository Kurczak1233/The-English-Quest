using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class addSampleTestQA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleTestQA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionDecorationPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstQuestionRadioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstQuestionAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondQuestionRadioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondQuestionAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdQuestionRadioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdQuestionAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTestQA", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleTestQA");
        }
    }
}
