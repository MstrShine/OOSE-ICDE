using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ILearningOutcomeUnitManager : IVersionedEntityManager<LearningOutcomeUnit>
    {
        Task<List<LearningOutcomeUnit>> GetByCourseId(Guid courseId);
    }
}
