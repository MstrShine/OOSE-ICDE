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
    public class LearningOutcomeUnitManager : VersionedEntityManager<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit, ILearningOutcomeUnitRepositorySession>, ILearningOutcomeUnitManager
    {
        public LearningOutcomeUnitManager(
            IEntityRepository<ILearningOutcomeUnitRepositorySession, Persistency.Database.Domain.LearningOutcomeUnit> repository, 
            IEntityMapper<Domain.LearningOutcomeUnit, Persistency.Database.Domain.LearningOutcomeUnit> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<LearningOutcomeUnit>> GetByCourseIdAsync(Guid courseId)
        {
            if(courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var learningOutcomeUnits = new List<LearningOutcomeUnit>();
            using(var session = _repository.CreateSession()) 
            { 
                var dbList = await session.GetByCourseIdAsync(courseId);
                learningOutcomeUnits = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return learningOutcomeUnits;
        }
    }
}
