using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class Lesson : VersionedDBEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Didactics { get; set; }

        public DateTime? Date { get; set; }

        public Guid? CoursePlanningId { get; set; }
    }
}
