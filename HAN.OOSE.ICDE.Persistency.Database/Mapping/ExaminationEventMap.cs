using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class ExaminationEventMap : VersionEntityMapper<ExaminationEvent>
    {
        public override void ConfigureExtension(EntityTypeBuilder<ExaminationEvent> builder)
        {
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Prerequisites);

            builder.Property(x => x.CoursePlanningId);
            builder.Property(x => x.ExamId);
        }
    }
}
