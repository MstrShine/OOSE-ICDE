using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class ExamMap : VersionEntityMapper<Exam>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.MinimumGrade).IsRequired();

            builder.Property(x => x.LearningOutcomeUnitId);

            builder.HasMany<LearningOutcome>().WithOne().HasForeignKey(x => x.ExamId);
            builder.HasMany<AssessmentDimension>().WithOne().HasForeignKey(x => x.ExamId);
            builder.HasMany<ExaminationEvent>().WithOne().HasForeignKey(x => x.ExamId);
        }
    }
}
