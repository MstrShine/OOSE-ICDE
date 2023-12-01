namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentCriteria : Entity
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int MinimumGrade { get; set; }

        public List<GradeDescription> GradeDescriptions { get; set; }

        public string Explanation { get; set; }
    }
}
