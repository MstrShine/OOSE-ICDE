using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class Competency : VersionedEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        [DefaultValue(null)]
        public Guid? CourseId { get; set; }

        [DefaultValue(null)]
        public Guid? LearningOutcomeUnitId { get; set; }
    }
}
