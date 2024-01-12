using HAN.OOSE.ICDE.API.Interfaces;
using HAN.OOSE.ICDE.Domain.Base;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HAN.OOSE.ICDE.API.Controllers.Base
{
    public abstract class VersionedEntityController<T> : BaseEntityController<T>, IVersionedEntityController<T> where T : VersionedEntity
    {
        protected VersionedEntityController(
            ILogger<BaseEntityController<T>> logger) : base(logger)
        {
        }

        protected Guid UserId
        {
            get
            {
                var claimIdentity = (HttpContext.User.Identity as ClaimsIdentity);
                if (claimIdentity != null)
                {
                    var value = claimIdentity.Claims.First(x => x.Type == "id").Value;
                    return Guid.Parse(value);
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public abstract Task<ActionResult<List<T>>> GetByVersionId(Guid versionId);
    }
}
