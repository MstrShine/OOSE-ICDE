using HAN.OOSE.ICDE.API.Interfaces;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Domain.Base;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers.Base
{
    public abstract class VersionedEntityController<T> : BaseEntityController<T>, IVersionedEntityController<T> where T : VersionedEntity
    {
        protected VersionedEntityController(
            ILogger<BaseEntityController<T>> logger) : base(logger)
        {
        }

        public abstract Task<ActionResult<List<T>>> GetByVersionId(Guid versionId);
    }
}
