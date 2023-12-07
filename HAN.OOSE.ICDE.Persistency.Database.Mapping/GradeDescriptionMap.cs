using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class GradeDescriptionMap : EntityMapper<GradeDescription>
    {
        public override void ConfigureExtension(EntityTypeBuilder<GradeDescription> builder)
        {
            builder.Property(x => x.Grade);
            builder.Property(x => x.Description);
        }
    }
}
