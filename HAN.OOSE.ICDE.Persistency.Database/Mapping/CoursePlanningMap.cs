using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CoursePlanningMap : VersionEntityMapper<CoursePlanning>
    {
        public override void ConfigureExtension(EntityTypeBuilder<CoursePlanning> builder)
        {
            builder.HasMany(x => x.Lessons).WithOne();
            builder.HasMany(x => x.Examinations).WithOne();
        }
    }
}
