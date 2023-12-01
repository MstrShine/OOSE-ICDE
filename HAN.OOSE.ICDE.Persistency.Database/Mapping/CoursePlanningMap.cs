using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CoursePlanningMap : VersionEntityMapper<CoursePlanning>
    {
        public override void ConfigureExtension(EntityTypeBuilder<CoursePlanning> builder)
        {
            builder.HasMany(x => x.Lessons).WithOne();
            builder.HasMany(x => x.Examinations).WithOne();
        }
    }
}
