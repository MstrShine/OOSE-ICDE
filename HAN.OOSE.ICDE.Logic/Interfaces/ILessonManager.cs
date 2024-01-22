using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ILessonManager : IVersionedEntityManager<Lesson>
    {
        Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId);

        Task<List<Lesson>> GetByLearningOutcomeIdAsync(Guid learningOutcomeId);
    }
}
