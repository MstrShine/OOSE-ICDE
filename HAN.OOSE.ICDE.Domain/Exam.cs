namespace HAN.OOSE.ICDE.Domain
{
    public class Exam : Entity
    {
        public int Weight { get; set; }

        public string Type { get; set; }

        public int MinimumGrade { get; set; }

        public List<LearningOutcome> LearningOutcomes { get; set; }

        public List<AssessmentDimension> AssessmentDimensions { get; set; }

        public List<ExaminationEvent> ExaminationEvents { get; set; }
    }
}
