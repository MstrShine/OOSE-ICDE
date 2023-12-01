namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentDimension : Entity
    {
        public string Description { get; set; }

        public List<AssessmentCriteria> Criterias { get; set; }
    }
}
