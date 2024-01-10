using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class LearningOutcome : VersionedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ExamId { get; set; }

        public Guid? LearningOutcomeUnitId { get; set; }

        public Guid? LessonId { get; set; }
    }
}
