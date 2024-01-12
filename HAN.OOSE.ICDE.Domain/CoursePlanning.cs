using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class CoursePlanning : VersionedEntity
    {
        [DefaultValue(null)]
        public Guid? CourseId { get; set; }
    }
}
