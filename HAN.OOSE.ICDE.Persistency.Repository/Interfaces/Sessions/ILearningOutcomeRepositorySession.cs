using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions
{
    public interface ILearningOutcomeRepositorySession : IVersionedEntityRepositorySession<LearningOutcome>
    {
        Task<List<LearningOutcome>> GetByExamId(Guid examId);

        Task<List<LearningOutcome>> GetByLearningOutcomeUnitId(Guid learningOutcomeUnitId);

        Task<List<LearningOutcome>> GetByLessonId(Guid lessonId);
    }
}
