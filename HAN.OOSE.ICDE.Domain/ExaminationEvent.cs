using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class ExaminationEvent : VersionedEntity
    {
        public string? Type { get; set; }

        public DateTime? Date { get; set; }

        public string? Prerequisites { get; set; }

        [DefaultValue(null)]
        public Guid? CoursePlanningId { get; set; }

        [DefaultValue(null)]
        public Guid? ExamId { get; set; }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Type)) return false;
            if (Date == null) return false;
            if (CoursePlanningId == null || CoursePlanningId == Guid.Empty) return false;
            if (ExamId == null || ExamId == Guid.Empty) return false;

            return true;
        }
    }
}
