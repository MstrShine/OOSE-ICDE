using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class AssessmentDimensionMap : VersionEntityMapper<AssessmentDimension>
    {
        public override void ConfigureExtension(EntityTypeBuilder<AssessmentDimension> builder)
        {
            builder.Property(x => x.Description);

            builder.HasMany(x => x.Criterias).WithOne();
        }
    }
}
