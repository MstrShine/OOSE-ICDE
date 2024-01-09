using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeMap : VersionEntityMapper<LearningOutcome>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcome> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);

            builder.Property(x => x.ExamId);
            builder.Property(x => x.LearningOutcomeUnitId);
            builder.Property(x => x.LessonId);
        }
    }
}
