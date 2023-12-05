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
    public class LessonManager : VersionedEntityManager<Domain.Lesson, Persistency.Database.Domain.Lesson>
    {
        public LessonManager(
            IEntityRepository<IVersionedEntityRepositorySession<Persistency.Database.Domain.Lesson>, Persistency.Database.Domain.Lesson> repository, 
            IEntityMapper<Domain.Lesson, Persistency.Database.Domain.Lesson> mapper) : base(repository, mapper)
        {
        }
    }
}
