using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeMap : EntityMapper<LearningOutcome>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcome> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
        }
    }
}
