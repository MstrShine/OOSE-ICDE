using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CourseMap : VersionEntityMapper<Course>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.StudyProgram).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.CollegeYear).IsRequired();
            builder.Property(x => x.CTE).IsRequired();

            builder.HasMany(x => x.LearningOutcomeUnits).WithOne();
            builder.HasMany(x => x.Competencies).WithOne();
            builder.HasOne(x => x.CoursePlanning).WithOne(x => x.Course).HasForeignKey<CoursePlanning>(x => x.CourseId);
        }
    }
}
