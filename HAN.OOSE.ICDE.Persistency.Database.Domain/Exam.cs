using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Exam : VersionDBEntity
    {
        public int Weight { get; set; }

        public string Type { get; set; }

        public int MinimumGrade { get; set; }

        public Guid LearningOutcomeUnitId { get; set; }
    }
}
