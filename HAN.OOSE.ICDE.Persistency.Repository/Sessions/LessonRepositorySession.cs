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
    public class LessonRepositorySession : VersionedRepositorySessionBase<Lesson>, ILessonRepositorySession
    {
        protected override DbSet<Lesson> Table => dataContext.Lessons;

        public LessonRepositorySession(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId)
        {
            if(coursePlanningId == Guid.Empty)
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

            if(coursePlanningId == Guid.Empty)
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
            await dataContext.SaveChangesAsync();
        }
    }
}
