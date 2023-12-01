using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeUnitMap : VersionEntityMapper<LearningOutcomeUnit>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcomeUnit> builder)
        {
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.CTE).IsRequired();
            builder.Property(x => x.MinimumGrade).IsRequired();

            builder.HasMany(x => x.Exams).WithOne();
            builder.HasMany(x => x.LearningOutcomes).WithOne();
            builder.HasMany(x => x.Competencies).WithOne();
        }
    }
}
