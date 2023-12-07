using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LessonMap : VersionEntityMapper<Lesson>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Didactics);
            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.CoursePlanningId);

            builder.HasMany(x => x.LearningOutcomes).WithOne().HasForeignKey(x => x.LessonId);
        }
    }
}
