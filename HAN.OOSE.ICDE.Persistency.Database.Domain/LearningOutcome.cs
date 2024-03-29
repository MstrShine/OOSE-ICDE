﻿using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class LearningOutcome : VersionedDBEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ExamId { get; set; }

        public Guid? LearningOutcomeUnitId { get; set; }
    }
}
