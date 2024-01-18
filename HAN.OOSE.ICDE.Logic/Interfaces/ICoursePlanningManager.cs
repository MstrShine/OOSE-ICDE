using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ICoursePlanningManager : IVersionedEntityManager<CoursePlanning>
    {
        Task<CoursePlanning> GetByCourseIdAsync(Guid courseId);
    }
}
