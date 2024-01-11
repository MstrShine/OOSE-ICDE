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
    public class ExamRepositorySession : VersionedRepositorySessionBase<Exam>, IExamRepositorySession
    {
        protected override DbSet<Exam> Table => dataContext.Exams;

        public ExamRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Exam>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId)
        {
            if(learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            return Table.Where(x => x.LearningOutcomeUnitId == learningOutcomeUnitId).ToListAsync();
        }

        public async Task ChangeLearningOutcomeUnitIdAsync(Guid examId, Guid learningOutcomeUnitId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(examId));
            }

            if(learningOutcomeUnitId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(learningOutcomeUnitId));
            }

            var toChange = await Table.SingleOrDefaultAsync(x => x.Id == examId);
            if(toChange == null)
            {
                throw new Exception($"Exam not found with Id: {examId}");
            }

            toChange.LearningOutcomeUnitId = learningOutcomeUnitId;
            Table.Update(toChange);
            await dataContext.SaveChangesAsync();
        }
    }
}
