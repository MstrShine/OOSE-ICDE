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
    public class AssessmentDimensionManager : VersionedEntityManager<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension, IAssessmentDimensionRepositorySession>, IAssessmentDimensionManager
    {
        private readonly IEntityRepository<IAssessmentCriteriaRepositorySession, Persistency.Database.Domain.AssessmentCriteria> _assessmentCriteriaRepository;

        public AssessmentDimensionManager(
            IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension> repository,
            IEntityMapper<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension> mapper,
            IEntityRepository<IAssessmentCriteriaRepositorySession, Persistency.Database.Domain.AssessmentCriteria> assessmentCriteriaRepository) : base(repository, mapper)
        {
            _assessmentCriteriaRepository = assessmentCriteriaRepository;
        }

        public async Task<List<AssessmentDimension>> GetByExamIdAsync(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var assessmentDimensions = new List<AssessmentDimension>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByExamIdAsync(examId);
                assessmentDimensions = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return assessmentDimensions;
        }

        public override async Task<AssessmentDimension> SaveAsync(AssessmentDimension entity)
        {
            var prevId = Guid.Parse(entity.Id.ToString());
            var saved = await base.SaveAsync(entity);
            if(prevId == Guid.Empty)
            {
                return saved;
            }

            using (var assessmentCriteriaSession = _assessmentCriteriaRepository.CreateSession())
            {
                var assessmentCriterias = await assessmentCriteriaSession.GetByAssessmentDimensionIdAsync(prevId);
                foreach (var criteria in assessmentCriterias)
                {
                    await assessmentCriteriaSession.ChangeAssessmentDimensionIdAsync(criteria.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
