using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
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
    public class ExaminationEventManager : VersionedEntityManager<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent, IExaminationEventRepositorySession>, IExaminationEventManager
    {
        public ExaminationEventManager(
            IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> repository,
            IEntityMapper<Domain.ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<ExaminationEvent>> GetByCoursePlanningId(Guid coursePlanningId)
        {
            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            var examinationEvents = new List<ExaminationEvent>();
            using(var session = _repository.CreateSession()) 
            {
                var dbList = await session.GetByCoursePlanningId(coursePlanningId);
                examinationEvents = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return examinationEvents;
        }

        public async Task<List<ExaminationEvent>> GetByExamId(Guid examId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var examinationEvents = new List<ExaminationEvent>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByExamId(examId);
                examinationEvents = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return examinationEvents;
        }
    }
}
