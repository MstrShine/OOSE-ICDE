using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions
{
    public interface ILessonRepositorySession : IVersionedEntityRepositorySession<Lesson>
    {
        Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId);

        Task<List<Lesson>> GetByLearningOutcomeIdAsync(Guid learningOutcomeId);

        Task ChangeCoursePlanningIdAsync(Guid lessonId, Guid coursePlanningId);

        Task ChangeLearningOutcomeIdAsync(Guid lessonId, Guid learningOutcomeId);
    }
}
