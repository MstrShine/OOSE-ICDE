using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Course : VersionDBEntity
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
