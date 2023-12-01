using HAN.OOSE.ICDE.Persistency.Database.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CourseMap : VersionEntityMapper<Course>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.StudyProgram);
            builder.Property(x => x.Code);
            builder.Property(x => x.CollegeYear);
            builder.Property(x => x.CTE);

            builder.HasMany(x => x.LearningOutcomeUnits).WithOne();
            builder.HasMany(x => x.Competencies).WithOne();
            builder.HasOne(x => x.CoursePlanning).WithOne(x => x.Course).HasForeignKey<CoursePlanning>(x => x.CourseId);
        }
    }
}
