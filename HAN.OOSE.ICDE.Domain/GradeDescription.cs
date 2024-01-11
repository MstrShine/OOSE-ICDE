using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class GradeDescription : VersionedEntity
    {
        public int Grade { get; set; }

        public string Description { get; set; }

        public Guid? AssessmentCriteriaId { get; set; }
    }
}
