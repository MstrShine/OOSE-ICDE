using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class ExamMap : VersionEntityMapper<Exam>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Code).IsRequired(false);
            builder.Property(x => x.Weight).HasDefaultValue(0);
            builder.Property(x => x.Type);
            builder.Property(x => x.MinimumGrade).HasDefaultValue(1);

            builder.Property(x => x.LearningOutcomeUnitId).IsRequired(false);

            builder.HasMany<LearningOutcome>().WithOne().HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<AssessmentDimension>().WithOne().HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<ExaminationEvent>().WithOne().HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
