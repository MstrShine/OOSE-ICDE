﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class AssessmentDimensionManager : VersionedEntityManager<AssessmentDimension, Persistency.Database.Domain.AssessmentDimension, IAssessmentDimensionRepositorySession>, IAssessmentDimensionManager
    {
        private readonly IEntityRepository<IAssessmentCriteriaRepositorySession, Persistency.Database.Domain.AssessmentCriteria> _assessmentCriteriaRepository;

        public AssessmentDimensionManager(
            IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension> repository,
            IEntityMapper<AssessmentDimension, Persistency.Database.Domain.AssessmentDimension> mapper,
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

            await DeleteAsync(prevId);

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
