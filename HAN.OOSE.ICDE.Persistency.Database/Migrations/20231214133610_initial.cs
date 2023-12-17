using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HAN.OOSE.ICDE.Persistency.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeYear = table.Column<int>(type: "int", nullable: false),
                    CTE = table.Column<int>(type: "int", nullable: false),
                    StudyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Studies_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Studies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoursePlannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePlannings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursePlannings_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomeUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CTE = table.Column<double>(type: "float", nullable: false),
                    MinimumGrade = table.Column<double>(type: "float", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomeUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningOutcomeUnits_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcomeUnits_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Didactics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoursePlanningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_CoursePlannings_CoursePlanningId",
                        column: x => x.CoursePlanningId,
                        principalTable: "CoursePlannings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lessons_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearningOutcomeUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competencies_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competencies_LearningOutcomeUnits_LearningOutcomeUnitId",
                        column: x => x.LearningOutcomeUnitId,
                        principalTable: "LearningOutcomeUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competencies_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumGrade = table.Column<int>(type: "int", nullable: false),
                    LearningOutcomeUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_LearningOutcomeUnits_LearningOutcomeUnitId",
                        column: x => x.LearningOutcomeUnitId,
                        principalTable: "LearningOutcomeUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exams_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssessmentDimensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentDimensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentDimensions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssessmentDimensions_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExaminationEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prerequisites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoursePlanningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationEvents_CoursePlannings_CoursePlanningId",
                        column: x => x.CoursePlanningId,
                        principalTable: "CoursePlannings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExaminationEvents_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExaminationEvents_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearningOutcomeUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_LearningOutcomeUnits_LearningOutcomeUnitId",
                        column: x => x.LearningOutcomeUnitId,
                        principalTable: "LearningOutcomeUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssessmentCriterias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    MinimumGrade = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentDimensionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentCriterias_AssessmentDimensions_AssessmentDimensionId",
                        column: x => x.AssessmentDimensionId,
                        principalTable: "AssessmentDimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssessmentCriterias_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GradeDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentCriteriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionCollection = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeDescriptions_AssessmentCriterias_AssessmentCriteriaId",
                        column: x => x.AssessmentCriteriaId,
                        principalTable: "AssessmentCriterias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradeDescriptions_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentCriterias_AssessmentDimensionId",
                table: "AssessmentCriterias",
                column: "AssessmentDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentCriterias_Author",
                table: "AssessmentCriterias",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentDimensions_Author",
                table: "AssessmentDimensions",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentDimensions_ExamId",
                table: "AssessmentDimensions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Competencies_Author",
                table: "Competencies",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Competencies_CourseId",
                table: "Competencies",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Competencies_LearningOutcomeUnitId",
                table: "Competencies",
                column: "LearningOutcomeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlannings_Author",
                table: "CoursePlannings",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlannings_CourseId",
                table: "CoursePlannings",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Author",
                table: "Courses",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudyId",
                table: "Courses",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationEvents_Author",
                table: "ExaminationEvents",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationEvents_CoursePlanningId",
                table: "ExaminationEvents",
                column: "CoursePlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationEvents_ExamId",
                table: "ExaminationEvents",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Author",
                table: "Exams",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LearningOutcomeUnitId",
                table: "Exams",
                column: "LearningOutcomeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDescriptions_AssessmentCriteriaId",
                table: "GradeDescriptions",
                column: "AssessmentCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDescriptions_Author",
                table: "GradeDescriptions",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_Author",
                table: "LearningOutcomes",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_ExamId",
                table: "LearningOutcomes",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_LearningOutcomeUnitId",
                table: "LearningOutcomes",
                column: "LearningOutcomeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_LessonId",
                table: "LearningOutcomes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomeUnits_Author",
                table: "LearningOutcomeUnits",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomeUnits_CourseId",
                table: "LearningOutcomeUnits",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Author",
                table: "Lessons",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CoursePlanningId",
                table: "Lessons",
                column: "CoursePlanningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competencies");

            migrationBuilder.DropTable(
                name: "ExaminationEvents");

            migrationBuilder.DropTable(
                name: "GradeDescriptions");

            migrationBuilder.DropTable(
                name: "LearningOutcomes");

            migrationBuilder.DropTable(
                name: "AssessmentCriterias");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "AssessmentDimensions");

            migrationBuilder.DropTable(
                name: "CoursePlannings");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "LearningOutcomeUnits");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Studies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
