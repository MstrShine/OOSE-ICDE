using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic
{
    public class CoursePlanningManager : VersionedEntityManager<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning, ICoursePlanningRepositorySession>, ICoursePlanningManager
    {
        private readonly IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> _examinationEventRepository;
        private readonly IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> _lessonRepository;

        public CoursePlanningManager(
            IEntityRepository<ICoursePlanningRepositorySession, Persistency.Database.Domain.CoursePlanning> repository,
            IEntityMapper<Domain.CoursePlanning, Persistency.Database.Domain.CoursePlanning> mapper,
            IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> examinationEventRepository,
            IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> lessonRepository) : base(repository, mapper)
        {
            _examinationEventRepository = examinationEventRepository;
            _lessonRepository = lessonRepository;
        }

        public async Task<CoursePlanning> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            CoursePlanning coursePlanning = null;
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByCourseIdAsync(courseId);
                coursePlanning = _mapper.ToEntity(dbList);
            }

            return coursePlanning;
        }

        public override async Task<CoursePlanning> SaveAsync(CoursePlanning entity)
        {
            var prevId = Guid.Parse(entity.Id.ToString());
            var saved = await base.SaveAsync(entity);
            if (prevId == Guid.Empty)
            {
                return saved;
            }

            using (var lessonSession = _lessonRepository.CreateSession())
            using (var examinationEventSession = _examinationEventRepository.CreateSession())
            {
                var lessons = lessonSession.GetByCoursePlanningIdAsync(prevId);
                var examinationEvents = examinationEventSession.GetByCoursePlanningIdAsync(prevId);

                foreach (var lesson in await lessons)
                {
                    await lessonSession.ChangeCoursePlanningIdAsync(lesson.Id, saved.Id);
                }

                foreach (var examinationEvent in await examinationEvents)
                {
                    await examinationEventSession.ChangeCoursePlanningIdAsync(examinationEvent.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
