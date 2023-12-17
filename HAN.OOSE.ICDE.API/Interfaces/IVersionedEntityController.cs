using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Interfaces
{
    public interface IVersionedEntityController<T> : IEntityController<T> where T : VersionedEntity
    {
        Task<ActionResult<List<T>>> GetByVersionId(Guid versionId);
    }
}
