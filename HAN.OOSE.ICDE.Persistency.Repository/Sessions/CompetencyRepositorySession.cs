using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class CompetencyRepositorySession : VersionedRepositorySessionBase<Competency>, ICompetencyRepositorySession
    {
        protected override DbSet<Competency> Table => dataContext.Competencies;

        public CompetencyRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Competency>> GetByCourseIdAsync(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return Table.Where(x => x.CourseId == courseId).ToListAsync();
        }

        public Task<List<Competency>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            return Table.Where(x => x.LearningOutcomeUnitId == learningOutcomeUnitId).ToListAsync();
        }

        public async Task ChangeCourseIdAsync(Guid competencyId, Guid courseId)
        {
            if (competencyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(competencyId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == competencyId);
            if (toChange == null)
            {
                throw new Exception($"Competency not found with Id: {competencyId}");
            }

            toChange.CourseId = courseId;
            Table.Update(toChange);
            await dataContext.SaveChangesAsync();
        }

        public async Task ChangeLearningOutcomeUnitIdAsync(Guid competencyId, Guid learningOutcomeUnitId)
        {
            if (competencyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(competencyId));
            }

            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == competencyId);
            if (toChange == null)
            {
                throw new Exception($"Competency not found with Id: {competencyId}");
            }

            toChange.LearningOutcomeUnitId = learningOutcomeUnitId;
            Table.Update(toChange);
            await dataContext.SaveChangesAsync();
        }
    }
}
