using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class removeNotDynamicPartsOfDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncouragementPositions");

            migrationBuilder.DropTable(
                name: "SampleTestQA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncouragementPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HtmlIdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceToCollapse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncouragementPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleTestQA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstQuestionAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstQuestionRadioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDecorationPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondQuestionAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondQuestionRadioName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdQuestionAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdQuestionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdQuestionRadioName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTestQA", x => x.Id);
                });
        }
    }
}
