using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class Lesson : VersionedEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Didactics { get; set; }

        public DateTime Date { get; set; }

        [DefaultValue(null)]
        public Guid? CoursePlanningId { get; set; }
    }
}
