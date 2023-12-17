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

        [HttpDelete("{id:guid}")]
        public override Task<ActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}")]
        public override Task<ActionResult<User>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public override Task<ActionResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public override Task<ActionResult<User>> Post(User entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:guid}")]
        public override Task<ActionResult<User>> Put(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
