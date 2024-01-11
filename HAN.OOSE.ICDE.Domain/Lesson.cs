using HAN.OOSE.ICDE.Domain.Base;

namespace HAN.OOSE.ICDE.Domain
{
    public class Lesson : VersionedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Didactics { get; set; }

        public DateTime Date { get; set; }

        public Guid? CoursePlanningId { get; set; }
    }
}
