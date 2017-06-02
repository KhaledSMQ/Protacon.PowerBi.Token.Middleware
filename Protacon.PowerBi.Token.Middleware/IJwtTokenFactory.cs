using System.IdentityModel.Tokens.Jwt;

namespace Protacon.PowerBi.Token.Middleware
{
    public interface IJwtTokenFactory
    {
        JwtSecurityToken CreateToken(string accessTokenToExchange);
    }
}