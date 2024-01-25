using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class LearningOutcomeUnitManager : VersionedEntityManager<LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit, ILearningOutcomeUnitRepositorySession>, ILearningOutcomeUnitManager
    {
        private readonly IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency> _competencyRepository;
        private readonly IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> _learningOutcomeRepository;
        private readonly IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam> _examRepository;

        public LearningOutcomeUnitManager(
            IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit> repository,
            IEntityMapper<LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit> mapper,
            IEntityRepository<ICompetencyRepositorySession, Persistency.Database.Domain.Competency> competencyRepository,
            IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> learningOutcomeRepository,
            IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam> examRepository) : base(repository, mapper)
        {
            _competencyRepository = competencyRepository;
            _learningOutcomeRepository = learningOutcomeRepository;
            _examRepository = examRepository;
        }

        public async Task<List<LearningOutcomeUnit>> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var learningOutcomeUnits = new List<LearningOutcomeUnit>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByCourseIdAsync(courseId);
                learningOutcomeUnits = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomeUnits;
        }

        public override async Task<LearningOutcomeUnit> SaveAsync(LearningOutcomeUnit entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var prevId = Guid.Parse(entity.Id.ToString());
            var saved = await base.SaveAsync(entity);
            if (prevId == Guid.Empty)
            {
                return saved;
            }

            using (var competencySession = _competencyRepository.CreateSession())
            using (var learningOutcomeSession = _learningOutcomeRepository.CreateSession())
            using (var examSession = _examRepository.CreateSession())
            {
                var competencies = competencySession.GetByLearningOutcomeUnitIdAsync(prevId);
                var learningOutcomes = learningOutcomeSession.GetByLearningOutcomeUnitIdAsync(prevId);
                var exams = examSession.GetByLearningOutcomeUnitIdAsync(prevId);

                foreach (var competency in await competencies)
                {
                    await competencySession.ChangeLearningOutcomeUnitIdAsync(competency.Id, saved.Id);
                }

                foreach (var learningOutcome in await learningOutcomes)
                {
                    await learningOutcomeSession.ChangeLearningOutcomeUnitIdAsync(learningOutcome.Id, saved.Id);
                }

                foreach (var exam in await exams)
                {
                    await examSession.ChangeLearningOutcomeUnitIdAsync(exam.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
