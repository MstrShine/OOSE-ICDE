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
    public class LearningOutcomeUnitManager : VersionedEntityManager<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit, ILearningOutcomeUnitRepositorySession>
    {
        public LearningOutcomeUnitManager(
            IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit> repository, 
            IEntityMapper<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit> mapper) : base(repository, mapper)
        {
        }
    }
}
