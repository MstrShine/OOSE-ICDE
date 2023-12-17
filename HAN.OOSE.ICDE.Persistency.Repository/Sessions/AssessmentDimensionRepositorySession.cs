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
    public class AssessmentDimensionRepositorySession : VersionedRepositorySessionBase<AssessmentDimension>, IAssessmentDimensionRepositorySession
    {
        protected override DbSet<AssessmentDimension> Table => dataContext.AssessmentDimensions;

        public AssessmentDimensionRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<AssessmentDimension>> GetByExamIdAsync(Guid examId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            return Table.Where(x => x.ExamId == examId).ToListAsync();
        }
    }
}
