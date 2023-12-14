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
    public class LearningOutcomeManager : VersionedEntityManager<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome, ILearningOutcomeRepositorySession>, ILearningOutcomeManager
    {
        public LearningOutcomeManager(
            IEntityRepository<ILearningOutcomeRepositorySession, Persistency.Database.Domain.LearningOutcome> repository, 
            IEntityMapper<Domain.LearningOutcome, Persistency.Database.Domain.LearningOutcome> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var learningOutcomes = new List<LearningOutcome>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByExamId(examId);
                learningOutcomes = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomes;
        }

        public async Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if(learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof (learningOutcomeUnitId));
            }

            var learningOutcomes = new List<LearningOutcome>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLearningOutcomeUnitId(learningOutcomeUnitId);
                learningOutcomes = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomes;
        }

        public async Task<List<LearningOutcome>> GetByLessonIdAsync(Guid lessonId)
        {
            if(lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof (lessonId));
            }

            var learningOutcomes = new List<LearningOutcome>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByLessonId(lessonId);
                learningOutcomes = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomes;
        }
    }
}
