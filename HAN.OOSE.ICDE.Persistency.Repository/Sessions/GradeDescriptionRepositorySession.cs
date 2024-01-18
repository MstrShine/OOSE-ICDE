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
    public class GradeDescriptionRepositorySession : VersionedRepositorySessionBase<GradeDescription>, IGradeDescriptionRepositorySession
    {
        protected override DbSet<GradeDescription> Table => dataContext.GradeDescriptions;

        public GradeDescriptionRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<GradeDescription>> GetByAssessmentCriteriaIdAsync(Guid assessmentCriteriaId)
        {
            if(assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            return Table.Where(x => x.AssessmentCriteriaId == assessmentCriteriaId).ToListAsync();
        }

        public async Task ChangeAssessmentCriteriaIdAsync(Guid gradeDescriptionId, Guid assessmentCriteriaId)
        {
            if (gradeDescriptionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(gradeDescriptionId));
            }

            if(assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == gradeDescriptionId);
            if(toChange == null)
            {
                throw new Exception($"GradeDescription not found with Id: {gradeDescriptionId}");
            }

            toChange.AssessmentCriteriaId = assessmentCriteriaId;
            Table.Update(toChange);
            await dataContext.SaveChangesAsync();
        }
    }
}
