using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class Competency : VersionedEntity
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        [DefaultValue(null)]
        public Guid? CourseId { get; set; }

        [DefaultValue(null)]
        public Guid? LearningOutcomeUnitId { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Code)) return false;
            if (string.IsNullOrEmpty(Name)) return false;
            if (CourseId == null || CourseId == Guid.Empty) return false;
            if (LearningOutcomeUnitId == null || LearningOutcomeUnitId == Guid.Empty) return false;

            return true;
        }
    }
}
