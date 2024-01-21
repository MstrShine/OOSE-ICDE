using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class LearningOutcome : VersionedEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        [DefaultValue(null)]
        public Guid? ExamId { get; set; }

        [DefaultValue(null)]
        public Guid? LearningOutcomeUnitId { get; set; }
    }
}
