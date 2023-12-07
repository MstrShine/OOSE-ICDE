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
                name: "Study",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Study", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Study_StudyId",
                        column: x => x.StudyId,
                        principalTable: "Study",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoursePlanning",
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
                    table.PrimaryKey("PK_CoursePlanning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePlanning_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursePlanning_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomeUnit",
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
                    table.PrimaryKey("PK_LearningOutcomeUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningOutcomeUnit_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcomeUnit_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
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
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_CoursePlanning_CoursePlanningId",
                        column: x => x.CoursePlanningId,
                        principalTable: "CoursePlanning",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lesson_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competency",
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
                    table.PrimaryKey("PK_Competency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competency_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competency_LearningOutcomeUnit_LearningOutcomeUnitId",
                        column: x => x.LearningOutcomeUnitId,
                        principalTable: "LearningOutcomeUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competency_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exam",
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
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_LearningOutcomeUnit_LearningOutcomeUnitId",
                        column: x => x.LearningOutcomeUnitId,
                        principalTable: "LearningOutcomeUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exam_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssessmentDimension",
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
                    table.PrimaryKey("PK_AssessmentDimension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentDimension_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssessmentDimension_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExaminationEvent",
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
                    table.PrimaryKey("PK_ExaminationEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationEvent_CoursePlanning_CoursePlanningId",
                        column: x => x.CoursePlanningId,
                        principalTable: "CoursePlanning",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExaminationEvent_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExaminationEvent_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcome",
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
                    table.PrimaryKey("PK_LearningOutcome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningOutcome_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcome_LearningOutcomeUnit_LearningOutcomeUnitId",
                        column: x => x.LearningOutcomeUnitId,
                        principalTable: "LearningOutcomeUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcome_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LearningOutcome_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssessmentCriteria",
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
                    table.PrimaryKey("PK_AssessmentCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentCriteria_AssessmentDimension_AssessmentDimensionId",
                        column: x => x.AssessmentDimensionId,
                        principalTable: "AssessmentDimension",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssessmentCriteria_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GradeDescription",
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
                    table.PrimaryKey("PK_GradeDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeDescription_AssessmentCriteria_AssessmentCriteriaId",
                        column: x => x.AssessmentCriteriaId,
                        principalTable: "AssessmentCriteria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradeDescription_User_Author",
                        column: x => x.Author,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentCriteria_AssessmentDimensionId",
                table: "AssessmentCriteria",
                column: "AssessmentDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentCriteria_Author",
                table: "AssessmentCriteria",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentDimension_Author",
                table: "AssessmentDimension",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentDimension_ExamId",
                table: "AssessmentDimension",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Competency_Author",
                table: "Competency",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Competency_CourseId",
                table: "Competency",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Competency_LearningOutcomeUnitId",
                table: "Competency",
                column: "LearningOutcomeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Author",
                table: "Course",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Course_StudyId",
                table: "Course",
                column: "StudyId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlanning_Author",
                table: "CoursePlanning",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlanning_CourseId",
                table: "CoursePlanning",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Author",
                table: "Exam",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_LearningOutcomeUnitId",
                table: "Exam",
                column: "LearningOutcomeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationEvent_Author",
                table: "ExaminationEvent",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationEvent_CoursePlanningId",
                table: "ExaminationEvent",
                column: "CoursePlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationEvent_ExamId",
                table: "ExaminationEvent",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDescription_AssessmentCriteriaId",
                table: "GradeDescription",
                column: "AssessmentCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeDescription_Author",
                table: "GradeDescription",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcome_Author",
                table: "LearningOutcome",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcome_ExamId",
                table: "LearningOutcome",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcome_LearningOutcomeUnitId",
                table: "LearningOutcome",
                column: "LearningOutcomeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcome_LessonId",
                table: "LearningOutcome",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomeUnit_Author",
                table: "LearningOutcomeUnit",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomeUnit_CourseId",
                table: "LearningOutcomeUnit",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Author",
                table: "Lesson",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CoursePlanningId",
                table: "Lesson",
                column: "CoursePlanningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competency");

            migrationBuilder.DropTable(
                name: "ExaminationEvent");

            migrationBuilder.DropTable(
                name: "GradeDescription");

            migrationBuilder.DropTable(
                name: "LearningOutcome");

            migrationBuilder.DropTable(
                name: "AssessmentCriteria");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "AssessmentDimension");

            migrationBuilder.DropTable(
                name: "CoursePlanning");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "LearningOutcomeUnit");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Study");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
