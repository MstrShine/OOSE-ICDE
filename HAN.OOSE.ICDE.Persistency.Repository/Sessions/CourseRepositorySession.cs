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
    public class CourseRepositorySession : VersionedRepositorySessionBase<Course>, ICourseRepositorySession
    {
        protected override DbSet<Course> Table => dataContext.Courses;

        public CourseRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Course>> GetByStudyId(Guid studyId)
        {
            if(studyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studyId));
            }

            return Table.Where(x => x.StudyId == studyId).ToListAsync();
        }
    }
}
