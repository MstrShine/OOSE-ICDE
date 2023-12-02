using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository
{
    public class LessonRepository : EntityRepository<IVersionedEntityRepositorySession<Lesson>, Lesson>
    {
        public LessonRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
