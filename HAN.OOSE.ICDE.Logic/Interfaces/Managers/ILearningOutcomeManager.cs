using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base;

namespace HAN.OOSE.ICDE.Logic.Interfaces.Managers
{
    public interface ILearningOutcomeManager : IVersionedEntityManager<LearningOutcome>
    {
        Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId);

        Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId);
    }
}
