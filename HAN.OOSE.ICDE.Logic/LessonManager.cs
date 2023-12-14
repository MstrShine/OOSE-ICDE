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
    public class LessonManager : VersionedEntityManager<Domain.Lesson, Persistency.Database.Domain.Lesson, ILessonRepositorySession>, ILessonManager
    {
        public LessonManager(
            IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> repository, 
            IEntityMapper<Domain.Lesson, Persistency.Database.Domain.Lesson> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if(coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            var lessons = new List<Lesson>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByCoursePlanningIdAsync(coursePlanningId);
                lessons = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return lessons;
        }
    }
}
