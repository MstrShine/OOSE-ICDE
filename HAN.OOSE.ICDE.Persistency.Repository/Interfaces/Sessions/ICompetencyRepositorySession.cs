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
        Task<List<Competency>> GetByCourseId(Guid courseId);

        Task<List<Competency>> GetByLearningOutcomeUnitId(Guid learningOutcomeId);
    }
}
