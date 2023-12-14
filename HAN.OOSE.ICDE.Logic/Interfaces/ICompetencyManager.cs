﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Interfaces
{
    public interface ICompetencyManager : IVersionedEntityManager<Competency>
    {
        Task<List<Competency>> GetByCourseIdAsync(Guid courseId);

        Task<List<Competency>> GetByLearningOutcomeUnitIdAsync(Guid learningOutcomeUnitId);
    }
}
