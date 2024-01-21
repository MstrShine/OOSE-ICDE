using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class AssessmentDimensionRepositorySession : VersionedRepositorySessionBase<AssessmentDimension>, IAssessmentDimensionRepositorySession
    {
        protected override DbSet<AssessmentDimension> Table => _DataContext.AssessmentDimensions;

        private readonly IAssessmentCriteriaRepositorySession _assessmentCriteriaRepositorySession;

        public AssessmentDimensionRepositorySession(DataContext dataContext, IAssessmentCriteriaRepositorySession assessmentCriteriaRepositorySession) : base(dataContext)
        {
            _assessmentCriteriaRepositorySession = assessmentCriteriaRepositorySession;
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

            entity.ExamId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<AssessmentDimension>> GetByExamIdAsync(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            return Table.Where(x => x.ExamId == examId).ToListAsync();
        }

        public async Task ChangeExamIdAsync(Guid assessmentDimensionId, Guid examId)
        {
            if (assessmentDimensionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(assessmentDimensionId));
            }

            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == assessmentDimensionId);
            if (toChange == null)
            {
                throw new Exception($"AssessmentDimension not found with Id: {assessmentDimensionId}");
            }

            toChange.ExamId = examId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
