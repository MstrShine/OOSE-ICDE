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

        protected override bool IsValidEntity()
        {
            if (base.IsValidEntity())
            {
                if (string.IsNullOrEmpty(Name)) return false;
                if (string.IsNullOrEmpty(Description)) return false;
                if (ExamId == null || ExamId == Guid.Empty) return false;
                if (LearningOutcomeUnitId == null || LearningOutcomeUnitId == Guid.Empty) return false;

                return true;
            }

            return false;
        }
    }
}
