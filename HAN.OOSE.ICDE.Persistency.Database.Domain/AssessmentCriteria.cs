namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class AssessmentCriteria : VersionDBEntity
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int MinimumGrade { get; set; }

        public string Explanation { get; set; }

        public Guid AssessmentDimensionId { get; set; }
    }
}
