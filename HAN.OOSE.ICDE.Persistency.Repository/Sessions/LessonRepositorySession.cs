using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class LessonRepositorySession : VersionedRepositorySessionBase<Lesson>, ILessonRepositorySession
    {
        protected override DbSet<Lesson> Table => _DataContext.Lessons;

        public LessonRepositorySession(DataContext dataContext) : base(dataContext)
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

            entity.CoursePlanningId = null;
            Table.Update(entity);

            var lessons = await _DataContext.LessonLearningOutcomes.Where(x => x.LessonId == id).ToListAsync();
            _DataContext.RemoveRange(lessons);

            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            return Table.Where(x => x.CoursePlanningId == coursePlanningId).ToListAsync();
        }

        public async Task ChangeCoursePlanningIdAsync(Guid lessonId, Guid coursePlanningId)
        {
            if (lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(lessonId));
            }

            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == lessonId);
            if (toChange == null)
            {
                throw new Exception($"Lesson not found with Id: {coursePlanningId}");
            }

            toChange.CoursePlanningId = coursePlanningId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetByLearningOutcomeIdAsync(Guid learningOutcomeId)
        {
            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            var lessonIds = await _DataContext.LessonLearningOutcomes.Where(x => x.LearningOutcomeId == learningOutcomeId).Select(x => x.LessonId).ToListAsync();
            var lessons = await Table.Where(x => lessonIds.Exists(y => x.Id == y)).ToListAsync();

            return lessons;
        }

        public async Task ChangeLearningOutcomeIdAsync(Guid lessonId, Guid learningOutcomeId)
        {
            if (lessonId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(lessonId));
            }

            if (learningOutcomeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeId));
            }

            var toChange = await _DataContext.LessonLearningOutcomes.Where(x => x.LessonId == lessonId).ToListAsync();
            if (toChange == null)
            {
                throw new Exception($"Lesson not found with Id: {learningOutcomeId}");
            }

            toChange.ForEach(x => x.LearningOutcomeId = learningOutcomeId);
            _DataContext.LessonLearningOutcomes.UpdateRange(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
