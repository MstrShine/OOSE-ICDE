using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CoursePlanningMap : VersionEntityMapper<CoursePlanning>
    {
        public override void ConfigureExtension(EntityTypeBuilder<CoursePlanning> builder)
        {
            builder.HasMany<Lesson>().WithOne().HasForeignKey(x => x.CoursePlanningId);
            builder.HasMany<ExaminationEvent>().WithOne().HasForeignKey(x => x.CoursePlanningId);
        }
    }
}
