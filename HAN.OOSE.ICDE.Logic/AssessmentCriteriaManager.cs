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
        public AssessmentCriteriaManager(
            IEntityRepository<IAssessmentCriteriaRepositorySession, Persistency.Database.Domain.AssessmentCriteria> repository, 
            IEntityMapper<Domain.AssessmentCriteria, Persistency.Database.Domain.AssessmentCriteria> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<AssessmentCriteria>> GetByAssessmentDimensionId(Guid assessmentDimensionId)
        {
            if(assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            var assessmentCriterias = new List<AssessmentCriteria>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByAssessmentDimensionId(assessmentDimensionId);
                assessmentCriterias = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return assessmentCriterias;
        }
    }
}
