using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class LearningOutcome : VersionDBEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ExamId { get; set; }

        public Guid? LearningOutcomeUnitId { get; set; }

        public Guid? LessonId { get; set; }
    }
}
