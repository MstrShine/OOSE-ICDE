namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Exam : VersionDBEntity
    {
        public int Weight { get; set; }

        public string Type { get; set; }

        public int MinimumGrade { get; set; }

        public List<LearningOutcome> LearningOutcomes { get; set; }

        public List<AssessmentDimension> AssessmentDimensions { get; set; }

        public List<ExaminationEvent> ExaminationEvents { get; set; }

        public Guid LearningOutcomeUnitId { get; set; }
    }
}
