using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class Course : VersionedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public int CollegeYear { get; set; }

        public int CTE { get; set; }

        public bool IsFinalized { get; set; }

        public Guid? StudyId { get; set; }
    }
}
