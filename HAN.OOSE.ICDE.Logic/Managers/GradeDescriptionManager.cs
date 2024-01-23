using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Managers.Base;
using HAN.OOSE.ICDE.Logic.Mapping.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Managers
{
    public class GradeDescriptionManager : VersionedEntityManager<GradeDescription, Persistency.Database.Domain.GradeDescription, IGradeDescriptionRepositorySession>, IGradeDescriptionManager
    {
        public GradeDescriptionManager(
            IEntityRepository<IGradeDescriptionRepositorySession, Persistency.Database.Domain.GradeDescription> repository,
            IEntityMapper<GradeDescription, Persistency.Database.Domain.GradeDescription> mapper) : base(repository, mapper)
        {
        }

        public async Task<List<GradeDescription>> GetByAssessmentCriteriaIdAsync(Guid assessmentCriteriaId)
        {
            if (assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            var gradeDescriptions = new List<GradeDescription>();
            using (var session = _repository.CreateSession())
            {
                var dbList = await session.GetByAssessmentCriteriaIdAsync(assessmentCriteriaId);
                gradeDescriptions = dbList.Select(x => _mapper.ToEntity(x)).ToList();
            }

            return gradeDescriptions;
        }
    }
}
