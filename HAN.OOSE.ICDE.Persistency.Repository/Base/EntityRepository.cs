using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Base
{
    public abstract class EntityRepository<T, E> : IEntityRepository<T, E> where T : IEntityRepositorySession<E> where E : DBEntity
    {
        protected readonly IServiceProvider _serviceProvider;

        protected EntityRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateSession()
        {
            return (T)_serviceProvider.GetRequiredService(typeof(T));
        }
    }
}
