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

        public Task<List<GradeDescription>> GetByAssessmentCriteriaId(Guid assessmentCriteriaId)
        {
            if(assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            return Table.Where(x => x.AssessmentCriteriaId == assessmentCriteriaId).ToListAsync();
        }
    }
}
