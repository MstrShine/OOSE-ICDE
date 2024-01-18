using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions
{
    public interface ICoursePlanningRepositorySession : IVersionedEntityRepositorySession<CoursePlanning>
    {
        Task<CoursePlanning> GetByCourseIdAsync(Guid courseId);

        Task ChangeCourseIdAsync(Guid coursePlanningId, Guid courseId);
    }
}
