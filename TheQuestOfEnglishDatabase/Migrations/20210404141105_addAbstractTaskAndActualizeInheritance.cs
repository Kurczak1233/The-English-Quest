using Microsoft.EntityFrameworkCore.Migrations;

namespace TheQuestOfEnglishDatabase.Migrations
{
    public partial class addAbstractTaskAndActualizeInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_ListegningQuizes_ListeningQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_Quizzes_GrammarQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_ReadingQuizes_ReadingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_SpeakingQuizzes_SpeakingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacementTestTasks_WritingQuizzes_WritingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_GrammarQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_ListeningQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_ReadingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_SpeakingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropIndex(
                name: "IX_PlacementTestTasks_WritingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "GrammarQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "GrammarTask_TaskType",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "ListeningQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "ReadingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "ReadingTask_TaskType",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "SpeakingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "SpeakingTask_TaskType",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "TaskType",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "WritingQuizId",
                table: "PlacementTestTasks");

            migrationBuilder.DropColumn(
                name: "WritingTask_TaskType",
                table: "PlacementTestTasks");

            migrationBuilder.CreateTable(
                name: "GrammarTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrammarQuizId = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFirstPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDecoratedPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSecondPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrammarTasks_Quizzes_GrammarQuizId",
                        column: x => x.GrammarQuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListegningTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListeningQuizId = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFirstPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDecoratedPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSecondPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListegningTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListegningTasks_ListegningQuizes_ListeningQuizId",
                        column: x => x.ListeningQuizId,
                        principalTable: "ListegningQuizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingQuizId = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFirstPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDecoratedPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSecondPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingTasks_ReadingQuizes_ReadingQuizId",
                        column: x => x.ReadingQuizId,
                        principalTable: "ReadingQuizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakingQuizId = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFirstPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDecoratedPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSecondPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingTasks_SpeakingQuizzes_SpeakingQuizId",
                        column: x => x.SpeakingQuizId,
                        principalTable: "SpeakingQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WritingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WritingQuizId = table.Column<int>(type: "int", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFirstPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionDecoratedPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionSecondPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthAnswear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WritingTasks_WritingQuizzes_WritingQuizId",
                        column: x => x.WritingQuizId,
                        principalTable: "WritingQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrammarTasks_GrammarQuizId",
                table: "GrammarTasks",
                column: "GrammarQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_ListegningTasks_ListeningQuizId",
                table: "ListegningTasks",
                column: "ListeningQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingTasks_ReadingQuizId",
                table: "ReadingTasks",
                column: "ReadingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingTasks_SpeakingQuizId",
                table: "SpeakingTasks",
                column: "SpeakingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_WritingTasks_WritingQuizId",
                table: "WritingTasks",
                column: "WritingQuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrammarTasks");

            migrationBuilder.DropTable(
                name: "ListegningTasks");

            migrationBuilder.DropTable(
                name: "ReadingTasks");

            migrationBuilder.DropTable(
                name: "SpeakingTasks");

            migrationBuilder.DropTable(
                name: "WritingTasks");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PlacementTestTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GrammarQuizId",
                table: "PlacementTestTasks",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "TaskType",
                table: "PlacementTestTasks",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_GrammarQuizId",
                table: "PlacementTestTasks",
                column: "GrammarQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_ListeningQuizId",
                table: "PlacementTestTasks",
                column: "ListeningQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_ReadingQuizId",
                table: "PlacementTestTasks",
                column: "ReadingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_SpeakingQuizId",
                table: "PlacementTestTasks",
                column: "SpeakingQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacementTestTasks_WritingQuizId",
                table: "PlacementTestTasks",
                column: "WritingQuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_ListegningQuizes_ListeningQuizId",
                table: "PlacementTestTasks",
                column: "ListeningQuizId",
                principalTable: "ListegningQuizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_Quizzes_GrammarQuizId",
                table: "PlacementTestTasks",
                column: "GrammarQuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_ReadingQuizes_ReadingQuizId",
                table: "PlacementTestTasks",
                column: "ReadingQuizId",
                principalTable: "ReadingQuizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_SpeakingQuizzes_SpeakingQuizId",
                table: "PlacementTestTasks",
                column: "SpeakingQuizId",
                principalTable: "SpeakingQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacementTestTasks_WritingQuizzes_WritingQuizId",
                table: "PlacementTestTasks",
                column: "WritingQuizId",
                principalTable: "WritingQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
