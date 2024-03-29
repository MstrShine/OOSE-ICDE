﻿using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAN.OOSE.ICDE.Persistency.Database.Mapping
{
    public class LessonMap : VersionEntityMapper<Lesson>
    {
        public override void ConfigureExtension(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Didactics).IsRequired(false);
            builder.Property(x => x.Date).IsRequired(false);

            builder.Property(x => x.LearningOutcomeId).IsRequired(false);
            builder.Property(x => x.CoursePlanningId).IsRequired(false);
        }
    }
}
