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
    public class ExamManager : VersionedEntityManager<Domain.Exam, Persistency.Database.Domain.Exam>
    {
        public ExamManager(
            IEntityRepository<IVersionedEntityRepositorySession<Persistency.Database.Domain.Exam>, Persistency.Database.Domain.Exam> repository, 
            IEntityMapper<Domain.Exam, Persistency.Database.Domain.Exam> mapper) : base(repository, mapper)
        {
        }
    }
}
