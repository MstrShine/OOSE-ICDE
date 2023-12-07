using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class LearningOutcomeUnit : VersionDBEntity
    {
        public string Code { get; set; }

        public double CTE { get; set; }

        public double MinimumGrade { get; set; }

        public Guid CourseId { get; set; }
    }
}
