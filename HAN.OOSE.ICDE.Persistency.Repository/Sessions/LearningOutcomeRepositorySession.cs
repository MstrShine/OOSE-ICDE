using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Sessions
{
    public class LearningOutcomeRepositorySession : VersionedRepositorySessionBase<LearningOutcome>, ILearningOutcomeRepositorySession
    {
        protected override DbSet<LearningOutcome> Table => dataContext.LearningOutcomes;

        public LearningOutcomeRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<LearningOutcome>> GetByExamIdAsync(Guid examId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            return Table.Where(x => x.ExamId == examId).ToListAsync();
        }

        public Task<List<LearningOutcome>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if(learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof (learningOutcomeUnitId));
            }

            return Table.Where(x => x.LearningOutcomeUnitId == learningOutcomeUnitId).ToListAsync();
        }

        public Task<List<LearningOutcome>> GetByLessonIdAsync(Guid lessonId)
        {
            if(lessonId == Guid.Empty)
            {
                throw new ArgumentNullException (nameof (lessonId));
            }

            return Table.Where(x => x.LessonId == lessonId).ToListAsync();
        }
    }
}
