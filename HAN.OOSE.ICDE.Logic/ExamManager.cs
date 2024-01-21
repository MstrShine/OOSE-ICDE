using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic
{
    public class ExamManager : VersionedEntityManager<Domain.Exam, Persistency.Database.Domain.Exam, IExamRepositorySession>, IExamManager
    {
        private readonly IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> _examinationEventRepository;
        private readonly IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension> _assessmentDimensionRepository;
        private readonly IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> _learningOutcomeRepository;

        public ExamManager(
            IEntityRepository<IExamRepositorySession, Persistency.Database.Domain.Exam> repository,
            IEntityMapper<Domain.Exam, Persistency.Database.Domain.Exam> mapper,
            IEntityRepository<IExaminationEventRepositorySession, Persistency.Database.Domain.ExaminationEvent> examinationEventRepository,
            IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension> assessmentDimensionRepository,
            IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> learningOutcomeRepository) : base(repository, mapper)
        {
            _examinationEventRepository = examinationEventRepository;
            _assessmentDimensionRepository = assessmentDimensionRepository;
            _learningOutcomeRepository = learningOutcomeRepository;
        }

        public async Task<List<Exam>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            var exams = new List<Exam>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLearningOutcomeUnitIdAsync(learningOutcomeUnitId);
                exams = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return exams;
        }

        public override async Task<Exam> SaveAsync(Exam entity)
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

            using (var examinationEventSession = _examinationEventRepository.CreateSession())
            using (var assessmentDimensionSession = _assessmentDimensionRepository.CreateSession())
            using (var learningOutcomeSession = _learningOutcomeRepository.CreateSession())
            {
                var examinationEvents = examinationEventSession.GetByExamIdAsync(prevId);
                var assessmentDimensions = assessmentDimensionSession.GetByExamIdAsync(prevId);
                var learningOutcomes = learningOutcomeSession.GetByExamIdAsync(prevId);

                foreach (var examinationEvent in await examinationEvents)
                {
                    await examinationEventSession.ChangeExamIdAsync(examinationEvent.Id, saved.Id);
                }

                foreach (var assessmentDimension in await assessmentDimensions)
                {
                    await assessmentDimensionSession.ChangeExamIdAsync(assessmentDimension.Id, saved.Id);
                }

                foreach (var learningOutcome in await learningOutcomes)
                {
                    await learningOutcomeSession.ChangeExamIdAsync(learningOutcome.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
