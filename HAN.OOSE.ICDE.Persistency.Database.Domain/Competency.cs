using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Competency : VersionedDBEntity
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public Guid? CourseId { get; set; }

        public Guid? LearningOutcomeUnitId { get; set; }
    }
}
