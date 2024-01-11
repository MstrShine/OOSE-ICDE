using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class ExaminationEvent : VersionedEntity
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Prerequisites { get; set; }

        public Guid? CoursePlanningId { get; set; }

        public Guid? ExamId { get; set; }
    }
}
