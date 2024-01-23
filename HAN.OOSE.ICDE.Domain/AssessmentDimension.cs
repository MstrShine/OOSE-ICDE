using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentDimension : VersionedEntity
    {
        public string? Description { get; set; }

        [DefaultValue(null)]
        public Guid? ExamId { get; set; }

        protected override bool IsValidEntity()
        {
            if (base.IsValidEntity())
            {
                if (string.IsNullOrEmpty(Description)) return false;
                if (ExamId == null || ExamId == Guid.Empty) return false;

                return true;
            }

            return false;
        }
    }
}
