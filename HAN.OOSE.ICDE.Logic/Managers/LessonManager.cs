using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class LessonManager : VersionedEntityManager<Lesson, Persistency.Database.Domain.Lesson, ILessonRepositorySession>, ILessonManager
    {
        private readonly IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> _learningOutcomeRepository;

        public LessonManager(
            IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> repository,
            IEntityMapper<Lesson, Persistency.Database.Domain.Lesson> mapper,
            IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> learningOutcomeRepository) : base(repository, mapper)
        {
            _learningOutcomeRepository = learningOutcomeRepository;
        }

        public async Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            var lessons = new List<Lesson>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByCoursePlanningIdAsync(coursePlanningId);
                lessons = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return lessons;
        }

        public async Task<List<Lesson>> GetByLearningOutcomeIdAsync(Guid learningOutcomeId)
        {
            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            var lessons = new List<Lesson>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLearningOutcomeIdAsync(learningOutcomeId);
                lessons = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return lessons;
        }

        public override async Task<Lesson> SaveAsync(Lesson entity)
        {
            var prevId = Guid.Parse(entity.Id.ToString());
            var saved = await base.SaveAsync(entity);

            if (prevId == Guid.Empty)
            {
                return saved;
            }

            await DeleteAsync(prevId);

            return saved;
        }
    }
}
