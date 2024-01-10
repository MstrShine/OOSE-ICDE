using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class GradeDescription : VersionDBEntity
    {
        public int Grade { get; set; }

        public string Description { get; set; }

        public Guid? AssessmentCriteriaId { get; set; }
    }
}
