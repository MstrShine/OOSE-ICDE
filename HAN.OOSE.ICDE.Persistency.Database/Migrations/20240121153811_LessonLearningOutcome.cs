using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HAN.OOSE.ICDE.Persistency.Database.Migrations
{
    /// <inheritdoc />
    public partial class LessonLearningOutcome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningOutcomes_Lessons_LessonId",
                table: "LearningOutcomes");

            migrationBuilder.DropIndex(
                name: "IX_LearningOutcomes_LessonId",
                table: "LearningOutcomes");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "LearningOutcomes");

            migrationBuilder.CreateTable(
                name: "LessonLearningOutcomes",
                columns: table => new
                {
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearningOutcomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLearningOutcomes", x => new { x.LessonId, x.LearningOutcomeId });
                    table.ForeignKey(
                        name: "FK_LessonLearningOutcomes_LearningOutcomes_LearningOutcomeId",
                        column: x => x.LearningOutcomeId,
                        principalTable: "LearningOutcomes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LessonLearningOutcomes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonLearningOutcomes_LearningOutcomeId",
                table: "LessonLearningOutcomes",
                column: "LearningOutcomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonLearningOutcomes");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "LearningOutcomes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_LessonId",
                table: "LearningOutcomes",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningOutcomes_Lessons_LessonId",
                table: "LearningOutcomes",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }
    }
}
