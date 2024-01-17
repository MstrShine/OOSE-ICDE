using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class AssessmentCriteriaMap : VersionEntityMapper<AssessmentCriteria>
    {
        public override void ConfigureExtension(EntityTypeBuilder<AssessmentCriteria> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Weight).IsRequired(false);
            builder.Property(x => x.MinimumGrade).IsRequired(false);
            builder.Property(x => x.Explanation).IsRequired(false);

            builder.HasMany<GradeDescription>().WithOne().HasForeignKey(x => x.AssessmentCriteriaId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
        }
    }
}
