using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces.Managers
{
    public interface ICoursePlanningManager : IVersionedEntityManager<CoursePlanning>
    {
        Task<CoursePlanning> GetByCourseIdAsync(Guid courseId);
    }
}
