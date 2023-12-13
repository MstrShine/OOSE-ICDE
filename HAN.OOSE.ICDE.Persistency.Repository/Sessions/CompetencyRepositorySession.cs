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
    public class CompetencyRepositorySession : VersionedRepositorySessionBase<Competency>, ICompetencyRepositorySession
    {
        protected override DbSet<Competency> Table => dataContext.Competencies;

        public CompetencyRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Competency>> GetByCourseId(Guid courseId)
        {
            if(courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return Table.Where(x => x.CourseId == courseId).ToListAsync();
        }

        public Task<List<Competency>> GetByLearningOutcomeUnitId(Guid learningOutcomeId)
        {
            if(learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            return Table.Where(x => x.LearningOutcomeUnitId == learningOutcomeId).ToListAsync();
        }
    }
}
