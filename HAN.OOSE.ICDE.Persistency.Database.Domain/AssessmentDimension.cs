namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class AssessmentDimension : VersionDBEntity
    {
        public string Description { get; set; }

        public List<AssessmentCriteria> Criterias { get; set; }

        public Guid ExamId { get; set; }
    }
}
