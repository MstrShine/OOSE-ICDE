using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class AssessmentCriteriaRepositorySession : VersionedRepositorySessionBase<AssessmentCriteria>, IAssessmentCriteriaRepositorySession
    {
        protected override DbSet<AssessmentCriteria> Table => _DataContext.AssessmentCriterias;

        public AssessmentCriteriaRepositorySession(DataContext dataContext) : base(dataContext)
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

            entity.AssessmentDimensionId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<AssessmentCriteria>> GetByAssessmentDimensionIdAsync(Guid assessmentDimensionId)
        {
            if (assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            return Table.Where(x => x.AssessmentDimensionId == assessmentDimensionId).ToListAsync();
        }

        public async Task ChangeAssessmentDimensionIdAsync(Guid assessmentCriteriaId, Guid assessmentDimensionId)
        {
            if (assessmentCriteriaId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentCriteriaId));
            }

            if (assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == assessmentCriteriaId);
            if (toChange == null)
            {
                throw new Exception($"AssessmentCriteria not found with Id: {assessmentCriteriaId}");
            }

            toChange.AssessmentDimensionId = assessmentDimensionId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
