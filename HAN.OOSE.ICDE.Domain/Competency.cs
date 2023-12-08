using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class Competency : VersionedEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid CourseId { get; set; }

        public Guid LearningOutcomeUnitId { get; set; }
    }
}
