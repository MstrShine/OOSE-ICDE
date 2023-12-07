using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class StudyMap : EntityMapper<Study>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Study> builder)
        {
            builder.Property(x => x.Name);

            builder.HasMany<Course>().WithOne().HasForeignKey(x => x.StudyId);
        }
    }
}
