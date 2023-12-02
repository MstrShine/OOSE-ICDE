namespace HAN.OOSE.ICDE.Domain
{
    public class LearningOutcomeUnit : VersionedEntity
    {
        public string Code { get; set; }

        public double CTE { get; set; }

        public double MinimumGrade { get; set; }

        public List<Exam> Exams { get; set; }

        public List<LearningOutcome> LearningOutcomes { get; set; }

        public List<Competency> Competencies { get; set; }
    }
}
