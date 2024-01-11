using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class GradeDescriptionMap : VersionEntityMapper<GradeDescription>
    {
        public override void ConfigureExtension(EntityTypeBuilder<GradeDescription> builder)
        {
            builder.Property(x => x.Grade).HasDefaultValue(1);
            builder.Property(x => x.Description).IsRequired(false);

            builder.Property(x => x.AssessmentCriteriaId).IsRequired(false);
        }
    }
}
