using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces.Managers
{
    public interface ILessonManager : IVersionedEntityManager<Lesson>
    {
        Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId);

        Task<List<Lesson>> GetByLearningOutcomeIdAsync(Guid learningOutcomeId);
    }
}
