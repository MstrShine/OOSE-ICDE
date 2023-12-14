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
    public class ExaminationEventRepositorySession : VersionedRepositorySessionBase<ExaminationEvent>, IExaminationEventRepositorySession
    {
        protected override DbSet<ExaminationEvent> Table => dataContext.ExaminationEvents;

        public ExaminationEventRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<ExaminationEvent>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if(coursePlanningId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(coursePlanningId));
            }

            return Table.Where(x => x.CoursePlanningId == coursePlanningId).ToListAsync();
        }

        public Task<List<ExaminationEvent>> GetByExamIdAsync(Guid examId)
        {
            if(examId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof (examId));
            }

            return Table.Where(x => x.ExamId == examId).ToListAsync();
        }
    }
}
