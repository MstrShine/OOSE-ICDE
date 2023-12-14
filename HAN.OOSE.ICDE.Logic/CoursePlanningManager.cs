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
    public class CoursePlanningManager : VersionedEntityManager<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning, ICoursePlanningRepositorySession>
    {
        public CoursePlanningManager(
            IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning> repository, 
            IEntityMapper<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning> mapper) : base(repository, mapper)
        {
        }
    }
}
