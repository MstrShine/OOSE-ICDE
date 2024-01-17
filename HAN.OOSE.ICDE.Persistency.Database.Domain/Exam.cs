using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Enums;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Exam : VersionDBEntity
    {
        public string? Name { get; set; }

        public string? Code { get; set; }

        public int? Weight { get; set; }

        public ExamType? Type { get; set; }

        public int? MinimumGrade { get; set; }

        public Guid? LearningOutcomeUnitId { get; set; }
    }
}
