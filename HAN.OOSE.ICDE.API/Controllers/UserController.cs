using HAN.OOSE.ICDE.API.JWT.Utils;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Domain.Enums;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;
        private readonly IJwtUtils _jwtUtils;

        public UserController(
            ILogger<UserController> logger,
            IUserManager userManager,
            IJwtUtils jwtUtils)
        {
            _logger = logger;
            _userManager = userManager;
            _jwtUtils = jwtUtils;
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var user = await _userManager.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _userManager.GetAllAsync();

            return Ok(users);
        }

        public record LoginModel(string Email, string Password);

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(LoginModel login)
        {
            if (string.IsNullOrEmpty(login.Email))
            {
                return BadRequest(new ArgumentNullException(nameof(login.Email)));
            }

            if (string.IsNullOrEmpty(login.Password))
            {
                return BadRequest(new ArgumentNullException(nameof(login.Password)));
            }

            var user = await _userManager.GetByEmailAsync(login.Email);
            if (user == null || user.IsDeleted)
            {
                return NotFound($"User with email {login.Email} does not exist");
            }

            if (!BCrypt.Net.BCrypt.EnhancedVerify(login.Password, user.Password))
            {
                return Unauthorized("Saved password does not match given password");
            }

            var token = _jwtUtils.GenerateToken(user);
            return Ok(token);
        }

        public record RegisterModel(string FirstName, string LastName, string Email, string Password);

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(RegisterModel register)
        {
            if (string.IsNullOrEmpty(register.FirstName))
            {
                return BadRequest(new ArgumentNullException(register.FirstName));
            }

            if (string.IsNullOrEmpty(register.LastName))
            {
                return BadRequest(new ArgumentNullException(register.LastName));
            }

            if (string.IsNullOrEmpty(register.Email))
            {
                return BadRequest(new ArgumentNullException(register.Email));
            }

            if (string.IsNullOrEmpty(register.Password))
            {
                return BadRequest(new ArgumentNullException(register.Password));
            }

            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(register.Password);

            var user = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                Password = hash,
                Role = Role.Student
            };

            user = await _userManager.SaveAsync(user);

            return Ok(user);
        }

        public record UpdatePasswordModel(string OldPassword, string NewPassword);

        [HttpPut("{id:guid}/password")]
        [Authorize]
        public async Task<ActionResult> UpdatePassword(Guid id, UpdatePasswordModel password)
        {
            if (string.IsNullOrEmpty(password.OldPassword))
            {
                return BadRequest(new ArgumentNullException(nameof(password.OldPassword)));
            }

            if (string.IsNullOrEmpty(password.NewPassword))
            {
                return BadRequest(new ArgumentNullException(nameof(password.NewPassword)));
            }

            var user = await _userManager.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var oldPassHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password.OldPassword);
            if (oldPassHash != user.Password)
            {
                return BadRequest("Old password not matching saved");
            }

            var newPassHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password.NewPassword);
            user.Password = newPassHash;
            await _userManager.UpdateAsync(user);

            return Ok();
        }
    }
}
