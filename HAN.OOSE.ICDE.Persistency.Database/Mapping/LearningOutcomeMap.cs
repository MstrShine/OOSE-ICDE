using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeMap : VersionEntityMapper<LearningOutcome>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcome> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description);
        }
    }
}
