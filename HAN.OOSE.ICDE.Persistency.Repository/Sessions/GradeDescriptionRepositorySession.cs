using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class GradeDescriptionRepositorySession : VersionedRepositorySessionBase<GradeDescription>, IGradeDescriptionRepositorySession
    {
        protected override DbSet<GradeDescription> Table => _DataContext.GradeDescriptions;

        public GradeDescriptionRepositorySession(DataContext dataContext) : base(dataContext)
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

            entity.AssessmentCriteriaId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<GradeDescription>> GetByAssessmentCriteriaIdAsync(Guid assessmentCriteriaId)
        {
            if (assessmentCriteriaId == Guid.Empty)
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

            if (assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == gradeDescriptionId);
            if (toChange == null)
            {
                throw new Exception($"GradeDescription not found with Id: {gradeDescriptionId}");
            }

            toChange.AssessmentCriteriaId = assessmentCriteriaId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
