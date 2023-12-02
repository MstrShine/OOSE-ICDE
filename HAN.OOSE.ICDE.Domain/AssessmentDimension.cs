namespace HAN.OOSE.ICDE.Domain
{
    public class AssessmentDimension : VersionedEntity
    {
        public string Description { get; set; }

        public List<AssessmentCriteria> Criterias { get; set; }
    }
}
