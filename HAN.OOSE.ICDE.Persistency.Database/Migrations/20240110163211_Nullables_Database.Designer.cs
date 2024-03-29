﻿// <auto-generated />
using System;
using HAN.OOSE.ICDE.Persistency.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HAN.OOSE.ICDE.Persistency.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240110163211_Nullables_Database")]
    partial class Nullables_Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.AssessmentCriteria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssessmentDimensionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinimumGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("AssessmentDimensionId");

                    b.HasIndex("Author");

                    b.ToTable("AssessmentCriterias");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.AssessmentDimension", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("ExamId");

                    b.ToTable("AssessmentDimensions");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Competency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("LearningOutcomeUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("CourseId");

                    b.HasIndex("LearningOutcomeUnitId");

                    b.ToTable("Competencies");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CTE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CollegeYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("YEAR(GETDATE())");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFinalized")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("StudyId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.CoursePlanning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CoursePlannings");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("LearningOutcomeUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MinimumGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("LearningOutcomeUnitId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.ExaminationEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoursePlanningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Prerequisites")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("CoursePlanningId");

                    b.HasIndex("ExamId");

                    b.ToTable("ExaminationEvents");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.GradeDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssessmentCriteriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentCriteriaId");

                    b.HasIndex("Author");

                    b.ToTable("GradeDescriptions");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcome", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LearningOutcomeUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("ExamId");

                    b.HasIndex("LearningOutcomeUnitId");

                    b.HasIndex("LessonId");

                    b.ToTable("LearningOutcomes");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcomeUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("CTE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double>("MinimumGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(1.0);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("CourseId");

                    b.ToTable("LearningOutcomeUnits");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Author")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoursePlanningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Didactics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VersionCollection")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Author");

                    b.HasIndex("CoursePlanningId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Study", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Studies");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.AssessmentCriteria", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.AssessmentDimension", null)
                        .WithMany()
                        .HasForeignKey("AssessmentDimensionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.AssessmentDimension", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Competency", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcomeUnit", null)
                        .WithMany()
                        .HasForeignKey("LearningOutcomeUnitId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Course", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Study", null)
                        .WithMany()
                        .HasForeignKey("StudyId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.CoursePlanning", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Course", null)
                        .WithOne()
                        .HasForeignKey("HAN.OOSE.ICDE.Persistency.Database.Domain.CoursePlanning", "CourseId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Exam", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcomeUnit", null)
                        .WithMany()
                        .HasForeignKey("LearningOutcomeUnitId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.ExaminationEvent", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.CoursePlanning", null)
                        .WithMany()
                        .HasForeignKey("CoursePlanningId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.GradeDescription", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.AssessmentCriteria", null)
                        .WithMany()
                        .HasForeignKey("AssessmentCriteriaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcome", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcomeUnit", null)
                        .WithMany()
                        .HasForeignKey("LearningOutcomeUnitId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.LearningOutcomeUnit", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HAN.OOSE.ICDE.Persistency.Database.Domain.Lesson", b =>
                {
                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HAN.OOSE.ICDE.Persistency.Database.Domain.CoursePlanning", null)
                        .WithMany()
                        .HasForeignKey("CoursePlanningId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
