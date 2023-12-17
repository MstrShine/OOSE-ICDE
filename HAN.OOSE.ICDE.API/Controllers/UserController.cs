using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.API.Interfaces;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IEntityManager<User> _userManager;

        public UserController(
            ILogger<UserController> logger,
            IEntityManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var user = await _userManager.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userManager.GetAllAsync();

            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User entity)
        {
            throw new NotImplementedException();
        }

        public record UpdatePasswordModel(string OldPassword, string NewPassword);

        [HttpPut("{id:guid}/password")]
        public async Task<ActionResult> UpdatePassword(Guid id, UpdatePasswordModel password)
        {
            throw new NotImplementedException();
        }
    }
}
