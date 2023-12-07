using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class ExamMap : EntityMapper<Exam>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Weight);
            builder.Property(x => x.Type);
            builder.Property(x => x.MinimumGrade);

            builder.HasMany(x => x.LearningOutcomes).WithOne();
            builder.HasMany(x => x.AssessmentDimensions).WithOne();
            builder.HasMany(x => x.ExaminationEvents).WithOne();
        }
    }
}
