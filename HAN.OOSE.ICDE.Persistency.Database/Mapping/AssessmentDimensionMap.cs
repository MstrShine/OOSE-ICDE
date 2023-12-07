﻿using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class AssessmentDimensionMap : VersionEntityMapper<AssessmentDimension>
    {
        public override void ConfigureExtension(EntityTypeBuilder<AssessmentDimension> builder)
        {
            builder.Property(x => x.Description);

            builder.Property(x => x.ExamId);

            builder.HasMany(x => x.Criterias).WithOne();
        }
    }
}
