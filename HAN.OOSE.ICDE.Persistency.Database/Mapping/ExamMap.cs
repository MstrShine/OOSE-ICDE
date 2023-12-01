using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class ExamMap : VersionEntityMapper<Exam>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.MinimumGrade).IsRequired();

            builder.HasMany(x => x.LearningOutcomes).WithOne();
            builder.HasMany(x => x.AssessmentDimensions).WithOne();
            builder.HasMany(x => x.ExaminationEvents).WithOne();
        }
    }
}
