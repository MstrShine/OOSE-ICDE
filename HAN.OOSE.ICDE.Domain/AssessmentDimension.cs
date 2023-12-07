using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentDimension : VersionedEntity
    {
        public string Description { get; set; }

        public Guid ExamId { get; set; }
    }
}
