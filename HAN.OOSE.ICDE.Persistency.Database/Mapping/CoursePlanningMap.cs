using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CoursePlanningMap : VersionEntityMapper<CoursePlanning>
    {
        public override void ConfigureExtension(EntityTypeBuilder<CoursePlanning> builder)
        {
            builder.Property(x => x.CourseId).IsRequired(false);

            builder.HasMany<Lesson>().WithOne().HasForeignKey(x => x.CoursePlanningId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<ExaminationEvent>().WithOne().HasForeignKey(x => x.CoursePlanningId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
