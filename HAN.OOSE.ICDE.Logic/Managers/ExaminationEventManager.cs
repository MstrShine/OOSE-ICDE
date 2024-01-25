using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class ExaminationEventManager : VersionedEntityManager<ExaminationEvent, Persistency.Database.Domain.ExaminationEvent, IExaminationEventRepositorySession>, IExaminationEventManager
    {
        public ExaminationEventManager(
            IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> repository,
            IEntityMapper<ExaminationEvent, Persistency.Database.Domain.ExaminationEvent> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<ExaminationEvent>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            var examinationEvents = new List<ExaminationEvent>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByCoursePlanningIdAsync(coursePlanningId);
                examinationEvents = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return examinationEvents;
        }

        public async Task<List<ExaminationEvent>> GetByExamIdAsync(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var examinationEvents = new List<ExaminationEvent>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByExamIdAsync(examId);
                examinationEvents = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return examinationEvents;
        }
    }
}
