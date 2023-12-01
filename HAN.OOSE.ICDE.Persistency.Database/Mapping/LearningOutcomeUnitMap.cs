using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LearningOutcomeUnitMap : VersionEntityMapper<LearningOutcomeUnit>
    {
        public override void ConfigureExtension(EntityTypeBuilder<LearningOutcomeUnit> builder)
        {
            builder.Property(x => x.Code);
            builder.Property(x => x.CTE);
            builder.Property(x => x.MinimumGrade);

            builder.HasMany(x => x.Exams).WithOne();
            builder.HasMany(x => x.LearningOutcomes).WithOne();
            builder.HasMany(x => x.Competencies).WithOne();
        }
    }
}
