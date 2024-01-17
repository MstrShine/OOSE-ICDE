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
    }
}
