using HAN.OOSE.ICDE.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HAN.OOSE.ICDE.API.JWT.Utils
{
    public class JwtUtils : IJwtUtils
    {
        private readonly JwtOptions _options;

        public JwtUtils(IConfiguration config)
        {
            _options = config.GetSection("JwtOptions").Get<JwtOptions>()!;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.FirstName + " " + user.LastName), 
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(_options.ExpirationSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
