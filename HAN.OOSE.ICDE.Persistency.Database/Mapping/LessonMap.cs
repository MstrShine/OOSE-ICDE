using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LessonMap : VersionEntityMapper<Lesson>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Didactics);
            builder.Property(x => x.Date);

            builder.HasMany(x => x.LearningOutcomes).WithOne();
        }
    }
}
