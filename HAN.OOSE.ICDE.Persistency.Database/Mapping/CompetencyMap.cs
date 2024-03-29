﻿using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class CompetencyMap : VersionEntityMapper<Competency>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Competency> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Code).IsRequired(false);

            builder.Property(x => x.CourseId).IsRequired(false);
            builder.Property(x => x.LearningOutcomeUnitId).IsRequired(false);
        }
    }
}
