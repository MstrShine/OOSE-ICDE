using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class Lesson : VersionedEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Didactics { get; set; }

        public DateTime? Date { get; set; }

        [DefaultValue(null)]
        public Guid? CoursePlanningId { get; set; }

        [DefaultValue(null)]
        public Guid? LearningOutcomeId { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name)) return false;
            if (string.IsNullOrEmpty(Didactics)) return false;
            if (Date == null) return false;
            if (CoursePlanningId == null || CoursePlanningId == Guid.Empty) return false;
            if (LearningOutcomeId == null || LearningOutcomeId == Guid.Empty) return false;

            return true;
        }
    }
}
