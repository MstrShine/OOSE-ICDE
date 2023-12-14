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
    public class ExamManager : VersionedEntityManager<Domain.Exam, Persistency.Database.Domain.Exam, IExamRepositorySession>
    {
        public ExamManager(
            IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam> repository, 
            IEntityMapper<Domain.Exam, Persistency.Database.Domain.Exam> mapper) : base(repository, mapper)
        {
        }
    }
}
