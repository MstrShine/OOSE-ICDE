using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class AssessmentCriteriaRepositorySession : VersionedRepositorySessionBase<AssessmentCriteria>, IAssessmentCriteriaRepositorySession
    {
        protected override DbSet<AssessmentCriteria> Table => dataContext.AssessmentCriterias;

        public AssessmentCriteriaRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<AssessmentCriteria>> GetByAssessmentDimensionIdAsync(Guid assessmentDimensionId)
        {
            if(assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            return Table.Where(x => x.AssessmentDimensionId == assessmentDimensionId).ToListAsync();
        }

        public async Task ChangeAssessmentDimensionIdAsync(Guid assessmentCriteriaId, Guid assessmentDimensionId)
        {
            if(assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            if(assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == assessmentCriteriaId);
            if(toChange == null)
            {
                throw new Exception($"AssessmentCriteria not found with Id: {assessmentCriteriaId}");
            }

            toChange.AssessmentDimensionId = assessmentDimensionId;
            Table.Update(toChange);
            await dataContext.SaveChangesAsync();
        }
    }
}
