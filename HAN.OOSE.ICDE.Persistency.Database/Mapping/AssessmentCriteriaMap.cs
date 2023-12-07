using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class AssessmentCriteriaMap : VersionEntityMapper<AssessmentCriteria>
    {
        public override void ConfigureExtension(EntityTypeBuilder<AssessmentCriteria> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.MinimumGrade).IsRequired();
            builder.Property(x => x.Explanation);

            builder.HasMany<GradeDescription>().WithOne().HasForeignKey(x => x.AssessmentCriteriaId);
        }
    }
}
