using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class ExaminationEventRepositorySession : VersionedRepositorySessionBase<ExaminationEvent>, IExaminationEventRepositorySession
    {
        protected override DbSet<ExaminationEvent> Table => _DataContext.ExaminationEvents;

        public ExaminationEventRepositorySession(DataContext dataContext) : base(dataContext)
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
            entity.ExamId = null;

            Table.Update(entity);
            await _DataContext.SaveChangesAsync();

            return;
        }

        public Task<List<ExaminationEvent>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            return Table.Where(x => x.CoursePlanningId == coursePlanningId).ToListAsync();
        }

        public Task<List<ExaminationEvent>> GetByExamIdAsync(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            return Table.Where(x => x.ExamId == examId).ToListAsync();
        }

        public async Task ChangeCoursePlanningIdAsync(Guid examinationEventId, Guid coursePlanningId)
        {
            if (examinationEventId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examinationEventId));
            }

            if (coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == examinationEventId);
            if (toChange == null)
            {
                throw new Exception($"ExaminationEvent not found with Id: {examinationEventId}");
            }

            toChange.CoursePlanningId = coursePlanningId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }

        public async Task ChangeExamIdAsync(Guid examinationEventId, Guid examId)
        {
            if (examinationEventId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examinationEventId));
            }

            if (examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == examinationEventId);
            if (toChange == null)
            {
                throw new Exception($"ExaminationEvent not found with Id: {examinationEventId}");
            }

            toChange.ExamId = examId;
            Table.Update(toChange);
            await _DataContext.SaveChangesAsync();
        }
    }
}
