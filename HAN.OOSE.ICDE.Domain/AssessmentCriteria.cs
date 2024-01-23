using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentCriteria : VersionedEntity
    {
        public string? Name { get; set; }

        public int? Weight { get; set; }

        public int? MinimumGrade { get; set; }

        public string? Explanation { get; set; }

        [DefaultValue(null)]
        public Guid? AssessmentDimensionId { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name)) return false;
            if (Weight == null || Weight < 0) return false;
            if (MinimumGrade == null || (MinimumGrade < 0 || MinimumGrade > 10)) return false;
            if (AssessmentDimensionId == null || AssessmentDimensionId == Guid.Empty) return false;

            return true;
        }
    }
}
