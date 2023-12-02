using HAN.OOSE.ICDE.Persistency.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Persistency.Repository.Interfaces
{
    public interface IVersionedEntityRepository<T> : IEntityRepository<T> where T : VersionDBEntity
    {
        Task<List<T>> GetByVersionIdAsync(Guid versionId);
    }
}
