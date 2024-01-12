using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class GradeDescription : VersionedEntity
    {
        public int Grade { get; set; }

        public string Description { get; set; }

        [DefaultValue(null)]
        public Guid? AssessmentCriteriaId { get; set; }
    }
}
