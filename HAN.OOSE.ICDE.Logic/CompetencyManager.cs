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
    public class CompetencyManager : VersionedEntityManager<Domain.Competency, Persistency.Database.Domain.Competency, ICompetencyRepositorySession>
    {
        public CompetencyManager(
            IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency> repository, 
            IEntityMapper<Domain.Competency, Persistency.Database.Domain.Competency> mapper) : base(repository, mapper)
        {
        }
    }
}
