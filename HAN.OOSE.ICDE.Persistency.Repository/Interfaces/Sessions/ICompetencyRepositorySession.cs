using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions
{
    public interface ICompetencyRepositorySession : IVersionedEntityRepositorySession<Competency>
    {
        Task<List<Competency>> GetByCourseIdAsync(Guid courseId);

        Task<List<Competency>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId);

        Task ChangeCourseIdAsync(Guid competencyId, Guid courseId);

        Task ChangeLearningOutcomeUnitIdAsync(Guid competencyId, Guid learningOutcomeUnitId);
    }
}
