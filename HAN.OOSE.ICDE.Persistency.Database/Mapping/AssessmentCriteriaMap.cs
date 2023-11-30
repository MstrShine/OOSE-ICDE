using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class AssessmentCriteriaMap : EntityMapper<AssessmentCriteria>
    {
        public override void ConfigureExtension(EntityTypeBuilder<AssessmentCriteria> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Weight);
            builder.Property(x => x.MinimumGrade);
            builder.Property(x => x.Explanation);

            builder.HasMany(x => x.GradeDescriptions).WithOne();
        }
    }
}
