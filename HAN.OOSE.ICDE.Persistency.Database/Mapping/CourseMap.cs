using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CourseMap : VersionEntityMapper<Course>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Code).IsRequired(false);
            builder.Property(x => x.CollegeYear).IsRequired(false);
            builder.Property(x => x.CTE).IsRequired(false);

            builder.Property(x => x.StudyId).IsRequired(false);

            builder.HasMany<LearningOutcomeUnit>().WithOne().HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<Competency>().WithOne().HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne<CoursePlanning>().WithOne().HasForeignKey<CoursePlanning>(x => x.CourseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
