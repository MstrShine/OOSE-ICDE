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
    public class ExaminationEventManager : VersionedEntityManager<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent>
    {
        public ExaminationEventManager(
            IEntityRepository<IVersionedEntityRepositorySession<Persistency.Database.Domain.ExaminationEvent>, Persistency.Database.Domain.ExaminationEvent> repository, 
            IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> mapper) : base(repository, mapper)
        {
        }
    }
}
