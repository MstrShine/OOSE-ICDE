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
    public class AssessmentCriteriaManager : VersionedEntityManager<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria, IAssessmentCriteriaRepositorySession>, IAssessmentCriteriaManager
    {
        private readonly IEntityRepository<IGradeDescriptionRepositorySession, Persistency.Database.Domain.GradeDescription> _gradeDescriptionRepository;

        public AssessmentCriteriaManager(
            IEntityRepository<IAssessmentCriteriaRepositorySession, Persistency.Database.Domain.AssessmentCriteria> repository, 
            IEntityMapper<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria> mapper,
            IEntityRepository<IGradeDescriptionRepositorySession, Persistency.Database.Domain.GradeDescription> gradeDescriptionRepository) : base(repository, mapper)
        {
            _gradeDescriptionRepository = gradeDescriptionRepository;
        }

        public async Task<List<AssessmentCriteria>> GetByAssessmentDimensionIdAsync(Guid assessmentDimensionId)
        {
            if(assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            var assessmentCriterias = new List<AssessmentCriteria>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByAssessmentDimensionIdAsync(assessmentDimensionId);
                assessmentCriterias = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return assessmentCriterias;
        }

        public override async Task<AssessmentCriteria> SaveAsync(AssessmentCriteria entity)
        {
            var prevId = Guid.Parse(entity.Id.ToString());
            var saved = await base.SaveAsync(entity);
            if(prevId == Guid.Empty)
            {
                return saved;
            }

            using(var gradeDescriptionSession = _gradeDescriptionRepository.CreateSession())
            {
                var gradeDescriptions = await gradeDescriptionSession.GetByAssessmentCriteriaIdAsync(prevId);
                foreach(var gradeDescription in gradeDescriptions)
                {
                    await gradeDescriptionSession.ChangeAssessmentCriteriaIdAsync(gradeDescription.Id, saved.Id);
                }
            }

            return saved;
        }
    }
}
