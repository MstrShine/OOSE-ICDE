﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base
{
    public interface IVersionedEntityManager<T> : IEntityManager<T> where T : VersionedEntity
    {
        Task<List<T>> GetByVersionIdAsync(Guid versionId);
    }
}
