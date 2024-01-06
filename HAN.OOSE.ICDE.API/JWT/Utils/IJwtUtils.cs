using HAN.OOSE.ICDE.Domain;

namespace HAN.OOSE.ICDE.API.JWT.Utils
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
    }
}
