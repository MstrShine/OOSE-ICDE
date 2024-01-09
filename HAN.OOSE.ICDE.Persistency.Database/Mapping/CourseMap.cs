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
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Code);
            builder.Property(x => x.CollegeYear);
            builder.Property(x => x.CTE);
            builder.Property(x => x.StudyId);

            builder.HasMany<LearningOutcomeUnit>().WithOne().HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<Competency>().WithOne().HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne<CoursePlanning>().WithOne().HasForeignKey<CoursePlanning>(x => x.CourseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
