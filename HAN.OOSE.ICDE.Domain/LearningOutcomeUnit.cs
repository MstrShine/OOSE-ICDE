using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class LearningOutcomeUnit : VersionedEntity
    {
        public string? Name { get; set; }

        public string? Code { get; set; }

        public double? CTE { get; set; }

        public double? MinimumGrade { get; set; }

        [DefaultValue(null)]
        public Guid? CourseId { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name)) return false;
            if (string.IsNullOrEmpty(Code)) return false;
            if (CTE == null || CTE < 0) return false;
            if (MinimumGrade == null || (MinimumGrade < 0 || MinimumGrade > 10)) return false;
            if (CourseId == null || CourseId == Guid.Empty) return false;

            return true;
        }
    }
}
