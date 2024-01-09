using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class GradeDescriptionMap : VersionEntityMapper<GradeDescription>
    {
        public override void ConfigureExtension(EntityTypeBuilder<GradeDescription> builder)
        {
            builder.Property(x => x.Grade);
            builder.Property(x => x.Description);

            builder.Property(x => x.AssessmentCriteriaId);
        }
    }
}
