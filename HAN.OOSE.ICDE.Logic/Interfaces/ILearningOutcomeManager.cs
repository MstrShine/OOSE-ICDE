using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ILearningOutcomeManager : IVersionedEntityManager<LearningOutcome>
    {
        Task AddLearningOutcomeToLesson(Guid learningOutcomeId, Guid lessonId);

        Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId);

        Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId);

        Task<List<LearningOutcome>> GetByLessonIdAsync(Guid lessonId);
    }
}
