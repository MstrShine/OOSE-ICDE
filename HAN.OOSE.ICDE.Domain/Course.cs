using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class Course : VersionedEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public int? CollegeYear { get; set; }

        public int? CTE { get; set; }

        [DefaultValue(false)]
        public bool IsFinalized { get; set; }

        [DefaultValue(null)]
        public Guid? StudyId { get; set; }

        protected override bool IsValidEntity()
        {
            if (base.IsValidEntity())
            {
                if (string.IsNullOrEmpty(Name)) return false;
                if (string.IsNullOrEmpty(Code)) return false;
                if (CollegeYear == null) return false;
                if (CTE == null || CTE < 0) return false;
                if (StudyId == null || StudyId == Guid.Empty) return false;

                return true;
            }

            return false;
        }
    }
}
