using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class Exam : VersionedEntity
    {
        public int Weight { get; set; }

        public string Type { get; set; }

        public int MinimumGrade { get; set; }

        public Guid LearningOutcomeUnitId { get; set; }
    }
}
