using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class AssessmentCriteria : VersionedDBEntity
    {
        public string? Name { get; set; }

        public int? Weight { get; set; }

        public int? MinimumGrade { get; set; }

        public string? Explanation { get; set; }

        public Guid? AssessmentDimensionId { get; set; }
    }
}
