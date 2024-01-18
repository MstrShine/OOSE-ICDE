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
    }
}
