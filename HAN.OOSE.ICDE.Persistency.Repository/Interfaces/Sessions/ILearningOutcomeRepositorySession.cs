using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions
{
    public interface ILearningOutcomeRepositorySession : IVersionedEntityRepositorySession<LearningOutcome>
    {
        Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId);

        Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId);

        Task ChangeExamIdAsync(Guid learningOutcomeId, Guid examId);

        Task ChangeLearningOutcomeUnitIdAsync(Guid learningOutcomeId, Guid learningOutcomeUnitId);
    }
}
