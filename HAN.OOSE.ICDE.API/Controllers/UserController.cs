using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.API.Interfaces;
using HAN.OOSE.ICDE.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController<User>
    {
        public UserController(ILogger<BaseEntityController<User>> logger) : base(logger)
        {
        }
    }
}
