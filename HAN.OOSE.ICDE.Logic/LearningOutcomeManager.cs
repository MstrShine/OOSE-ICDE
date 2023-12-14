using HAN.OOSE.ICDE.Logic.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic
{
    public class LearningOutcomeManager : VersionedEntityManager<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome, ILearningOutcomeRepositorySession>
    {
        public LearningOutcomeManager(
            IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> repository, 
            IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> mapper) : base(repository, mapper)
        {
        }
    }
}
