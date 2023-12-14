using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ILearningOutcomeManager : IVersionedEntityManager<LearningOutcome>
    {
        Task<List<LearningOutcome>> GetByExamId(Guid examId);

        Task<List<LearningOutcome>> GetByLearningOutcomeUnitId(Guid learningOutcomeUnitId);

        Task<List<LearningOutcome>> GetByLessonId(Guid lessonId);
    }
}
