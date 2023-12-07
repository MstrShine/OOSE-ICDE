using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
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

            builder.HasMany<LearningOutcomeUnit>().WithOne().HasForeignKey(x => x.CourseId);
            builder.HasMany<Competency>().WithOne().HasForeignKey(x => x.CourseId);
            builder.HasOne<CoursePlanning>().WithOne().HasForeignKey<CoursePlanning>(x => x.CourseId);
        }
    }
}
