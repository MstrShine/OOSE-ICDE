using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic
{
    public class AssessmentCriteriaManager : VersionedEntityManager<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria>
    {
        public AssessmentCriteriaManager(
            IEntityRepository<IVersionedEntityRepositorySession<Persistency.Database.Domain.AssessmentCriteria>, Persistency.Database.Domain.AssessmentCriteria> repository, 
            IEntityMapper<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria> mapper) : base(repository, mapper)
        {
        }
    }
}
