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
    public class CoursePlanningRepositorySession : VersionedRepositorySessionBase<CoursePlanning>, ICoursePlanningRepositorySession
    {
        protected override DbSet<CoursePlanning> Table => dataContext.CoursePlannings;

        public CoursePlanningRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<CoursePlanning>> GetByCourseId(Guid courseId)
        {
            if(courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return Table.Where(x => x.CourseId == courseId).ToListAsync();
        }
    }
}
