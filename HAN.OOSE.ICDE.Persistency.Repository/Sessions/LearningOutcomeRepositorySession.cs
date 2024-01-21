using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class LearningOutcomeRepositorySession : VersionedRepositorySessionBase<LearningOutcome>, ILearningOutcomeRepositorySession
    {
        protected override DbSet<LearningOutcome> Table => _DataContext.LearningOutcomes;

        public LearningOutcomeRepositorySession(DataContext dataContext) : base(dataContext)
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

            entity.ExamId = null;
            entity.LearningOutcomeUnitId = null;
            entity.LessonId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            return Table.Where(x => x.ExamId == examId).ToListAsync();
        }

        public Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            return Table.Where(x => x.LearningOutcomeUnitId == learningOutcomeUnitId).ToListAsync();
        }

        public Task<List<LearningOutcome>> GetByLessonIdAsync(Guid lessonId)
        {
            if (lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(lessonId));
            }

            return Table.Where(x => x.LessonId == lessonId).ToListAsync();
        }

        public async Task ChangeExamIdAsync(Guid learningOutcomeId, Guid examId)
        {
            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == learningOutcomeId);
            if (toChange == null)
            {
                throw new Exception($"LearningOutcome not found with Id: {learningOutcomeId}");
            }

            toChange.ExamId = examId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }

        public async Task ChangeLearningOutcomeUnitIdAsync(Guid learningOutcomeId, Guid learningOutcomeUnitId)
        {
            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            if (learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == learningOutcomeId);
            if (toChange == null)
            {
                throw new Exception($"LearningOutcome not found with Id: {learningOutcomeId}");
            }

            toChange.LearningOutcomeUnitId = learningOutcomeUnitId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }

        public async Task ChangeLessonIdAsync(Guid learningOutcomeId, Guid lessonId)
        {
            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            if (lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(lessonId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == learningOutcomeId);
            if (toChange == null)
            {
                throw new Exception($"LearningOutcome not found with Id: {learningOutcomeId}");
            }

            toChange.LessonId = lessonId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
