using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class LearningOutcomeUnitRepositorySession : VersionedRepositorySessionBase<LearningOutcomeUnit>, ILearningOutcomeUnitRepositorySession
    {
        protected override DbSet<LearningOutcomeUnit> Table => _DataContext.LearningOutcomeUnits;

        public LearningOutcomeUnitRepositorySession(DataContext dataContext) : base(dataContext)
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

        public Task<List<LearningOutcomeUnit>> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return Table.Where(x => x.CourseId == courseId).ToListAsync();
        }

        public async Task ChangeCourseIdAsync(Guid learningOutcomeUnitId, Guid courseId)
        {
            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == learningOutcomeUnitId);
            if (toChange == null)
            {
                throw new Exception($"LearningOutcomeUnit not found with Id: {learningOutcomeUnitId}");
            }

            toChange.CourseId = courseId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
