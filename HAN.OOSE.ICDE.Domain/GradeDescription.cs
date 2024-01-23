using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class GradeDescription : VersionedEntity
    {
        public int? Grade { get; set; }

        public string? Description { get; set; }

        [DefaultValue(null)]
        public Guid? AssessmentCriteriaId { get; set; }

        public override bool IsValid()
        {
            if (Grade == null || (Grade < 0 || Grade > 10)) return false;
            if (AssessmentCriteriaId == null || AssessmentCriteriaId == Guid.Empty) return false;

            return true;
        }
    }
}
