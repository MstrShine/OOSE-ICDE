using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic
{
    public class LearningOutcomeManager : VersionedEntityManager<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome, ILearningOutcomeRepositorySession>, ILearningOutcomeManager
    {
        private readonly IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> _lessonRepository;

        public LearningOutcomeManager(
            IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> repository,
            IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> mapper,
            IEntityRepository<ILessonRepositorySession, Persistency.Database.Domain.Lesson> lessonRepository) : base(repository, mapper)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task AddLearningOutcomeToLesson(Guid learningOutcomeId, Guid lessonId)
        {
            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            if (lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(lessonId));
            }

            using (var session = _repository.CreateSession())
            {
                await session.AddLearningOutcomeToLesson(learningOutcomeId, lessonId);
            }
        }

        public async Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var learningOutcomes = new List<LearningOutcome>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByExamIdAsync(examId);
                learningOutcomes = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomes;
        }

        public async Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            var learningOutcomes = new List<LearningOutcome>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLearningOutcomeUnitIdAsync(learningOutcomeUnitId);
                learningOutcomes = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomes;
        }

        public async Task<List<LearningOutcome>> GetByLessonIdAsync(Guid lessonId)
        {
            if (lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(lessonId));
            }

            var learningOutcomes = new List<LearningOutcome>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLessonIdAsync(lessonId);
                learningOutcomes = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomes;
        }

        public override async Task<LearningOutcome> SaveAsync(LearningOutcome entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var prevId = entity.Id;
            var saved = await base.SaveAsync(entity);
            if (prevId == Guid.Empty)
            {
                return saved;
            }

            using (var session = _lessonRepository.CreateSession())
            {
                var lessons = await session.GetByLearningOutcomeIdAsync(prevId);
                foreach (var lesson in lessons)
                {
                    await session.ChangeLearningOutcomeIdAsync(lesson.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
