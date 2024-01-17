using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeUnitMap : VersionEntityMapper<LearningOutcomeUnit>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcomeUnit> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Code).IsRequired(false);
            builder.Property(x => x.CTE).IsRequired(false);
            builder.Property(x => x.MinimumGrade).IsRequired(false);

            builder.Property(x => x.CourseId).IsRequired(false);

            builder.HasMany<Exam>().WithOne().HasForeignKey(x => x.LearningOutcomeUnitId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<LearningOutcome>().WithOne().HasForeignKey(x => x.LearningOutcomeUnitId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasMany<Competency>().WithOne().HasForeignKey(x => x.LearningOutcomeUnitId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
