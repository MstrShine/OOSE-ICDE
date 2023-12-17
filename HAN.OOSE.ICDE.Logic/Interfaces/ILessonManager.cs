using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ILessonManager : IVersionedEntityManager<Lesson>
    {
        Task<List<Lesson>> GetByCoursePlanningIdAsync(Guid coursePlanningId);
    }
}
