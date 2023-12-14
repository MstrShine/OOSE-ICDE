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
        public AssessmentDimensionManager(
            IEntityRepository<IAssessmentDimensionRepositorySession, Persistency.Database.Domain.AssessmentDimension> repository, 
            IEntityMapper<Domain.AssessmentDimension, Persistency.Database.Domain.AssessmentDimension> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<AssessmentDimension>> GetByExamId(Guid examId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var assessmentDimensions = new List<AssessmentDimension>();
            using(var session = _repository.CreateSession())
            {
                var dbList = await session.GetByExamId(examId);
                assessmentDimensions = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return assessmentDimensions;
        }
    }
}
