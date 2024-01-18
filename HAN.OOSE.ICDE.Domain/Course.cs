using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class Course : VersionedEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public int? CollegeYear { get; set; }

        public int? CTE { get; set; }

        [DefaultValue(false)]
        public bool IsFinalized { get; set; }

        [DefaultValue(null)]
        public Guid? StudyId { get; set; }
    }
}
