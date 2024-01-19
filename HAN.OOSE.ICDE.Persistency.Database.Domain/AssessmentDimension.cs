using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class AssessmentDimension : VersionedDBEntity
    {
        public string? Description { get; set; }

        public Guid? ExamId { get; set; }
    }
}
