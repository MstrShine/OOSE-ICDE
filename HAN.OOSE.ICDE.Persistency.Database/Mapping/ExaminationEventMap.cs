using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class ExaminationEventMap : VersionEntityMapper<ExaminationEvent>
    {
        public override void ConfigureExtension(EntityTypeBuilder<ExaminationEvent> builder)
        {
            builder.Property(x => x.Type);
            builder.Property(x => x.Date);
            builder.Property(x => x.Prerequisites);
        }
    }
}
