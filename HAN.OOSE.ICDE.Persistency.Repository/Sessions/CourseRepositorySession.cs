using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class CourseRepositorySession : VersionedRepositorySessionBase<Course>, ICourseRepositorySession
    {
        protected override DbSet<Course> Table => _DataContext.Courses;

        public CourseRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await Table.SingleOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception($"Could not find Id: {id} in Table {nameof(_Type)}");
            }

            entity.StudyId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<Course>> GetByStudyIdAsync(Guid studyId)
        {
            if (studyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studyId));
            }

            return Table.Where(x => x.StudyId == studyId).ToListAsync();
        }
    }
}
