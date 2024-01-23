using HAN.OOSE.ICDE.Domain.Base;
using System.ComponentModel;

namespace HAN.OOSE.ICDE.Domain
{
    public class CoursePlanning : VersionedEntity
    {
        [DefaultValue(null)]
        public Guid? CourseId { get; set; }

        protected override bool IsValidEntity()
        {
            if (base.IsValidEntity())
            {
                if (CourseId == null || CourseId == Guid.Empty) return false;

                return true;
            }

            return false;
        }
    }
}
