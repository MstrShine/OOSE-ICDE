using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace HAN.OOSE.ICDE.Persistency.Database
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration) : base()
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly((typeof(DataContext).Assembly));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString, b =>
            {
                b.EnableRetryOnFailure();
            }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            if (Debugger.IsAttached)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        #region DbSets
        public DbSet<AssessmentCriteria> AssessmentCriterias { get; set; }

        public DbSet<AssessmentDimension> AssessmentDimensions { get; set; }

        public DbSet<Competency> Competencies { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CoursePlanning> CoursePlannings { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<ExaminationEvent> ExaminationEvents { get; set; }

        public DbSet<GradeDescription> GradeDescriptions { get; set; }

        public DbSet<LearningOutcome> LearningOutcomes { get; set; }

        public DbSet<LearningOutcomeUnit> LearningOutcomeUnits { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<User> Users { get; set; }
        #endregion
    }
}
