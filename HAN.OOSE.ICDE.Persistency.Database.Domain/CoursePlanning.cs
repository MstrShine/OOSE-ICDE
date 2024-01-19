using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Domain
{
    public class CoursePlanning : VersionedDBEntity
    {
        public Guid? CourseId { get; set; }
    }
}
