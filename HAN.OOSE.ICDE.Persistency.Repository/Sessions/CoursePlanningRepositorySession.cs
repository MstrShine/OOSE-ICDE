using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class CoursePlanningRepositorySession : VersionedRepositorySessionBase<CoursePlanning>, ICoursePlanningRepositorySession
    {
        protected override DbSet<CoursePlanning> Table => _DataContext.CoursePlannings;

        public CoursePlanningRepositorySession(DataContext dataContext) : base(dataContext)
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

            entity.CourseId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<CoursePlanning> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return Table.FirstOrDefaultAsync(x => x.CourseId == courseId);
        }

        public async Task ChangeCourseIdAsync(Guid coursePlanningId, Guid courseId)
        {
            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == coursePlanningId);
            if (toChange == null)
            {
                throw new Exception($"CoursePlanning not found with Id: {coursePlanningId}");
            }

            toChange.CourseId = courseId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
