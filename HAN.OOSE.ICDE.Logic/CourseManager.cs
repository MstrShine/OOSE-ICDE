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
    public class CourseManager : VersionedEntityManager<Domain.Course, Persistency.Database.Domain.Course>
    {
        public CourseManager(
            IEntityRepository<IVersionedEntityRepositorySession<Persistency.Database.Domain.Course>, Persistency.Database.Domain.Course> repository, 
            IEntityMapper<Domain.Course, Persistency.Database.Domain.Course> mapper) : base(repository, mapper)
        {
        }
    }
}
