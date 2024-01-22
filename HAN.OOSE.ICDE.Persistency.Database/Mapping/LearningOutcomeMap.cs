using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeMap : VersionEntityMapper<LearningOutcome>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcome> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);

            builder.Property(x => x.ExamId).IsRequired(false);
            builder.Property(x => x.LearningOutcomeUnitId).IsRequired(false);

            builder.HasMany<Lesson>().WithOne().HasForeignKey(x => x.LearningOutcomeId).IsRequired(false);
        }
    }
}
