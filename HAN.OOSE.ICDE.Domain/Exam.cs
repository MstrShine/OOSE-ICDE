using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Domain.Enums;

namespace HAN.OOSE.ICDE.Domain
{
    public class Exam : VersionedEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int Weight { get; set; }

        public ExamType Type { get; set; }

        public int MinimumGrade { get; set; }

        public Guid LearningOutcomeUnitId { get; set; }
    }
}
