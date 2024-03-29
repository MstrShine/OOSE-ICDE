﻿using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Interfaces.Managers.Base
{
    public interface IEntityManager<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> SaveAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}
