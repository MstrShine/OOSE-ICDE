using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class LearningOutcomeUnit : VersionedEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public double CTE { get; set; }

        public double MinimumGrade { get; set; }

        public Guid? CourseId { get; set; }
    }
}
