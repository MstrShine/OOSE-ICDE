using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LessonLearningOutcomeMap : IEntityTypeConfiguration<LessonLearningOutcome>
    {
        public void Configure(EntityTypeBuilder<LessonLearningOutcome> builder)
        {
            builder.Property(x => x.LessonId).IsRequired();
            builder.Property(x => x.LearningOutcomeId).IsRequired();
        }
    }
}
