using HAN.OOSE.ICDE.Persistency.Database.Domain;
using HAN.OOSE.ICDE.Persistency.Database.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Database.Repository.Interfaces.Sessions
{
    public interface IVersionedEntityRepositorySession<T> : IEntityRepositorySession<T> where T : VersionDBEntity
    {
        Task<List<T>> GetByVersionIdAsync(Guid versionId);
    }
}
