using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Protacon.PowerBi.Token.Middleware
{
    public class TokenFactory : IJwtTokenFactory
    {
        private readonly string _accessTokenValidationSecret = "somerandomsecrethereoujea";
        private readonly string _powerBiAccessSecret = "/aiEu1GPWiZlHFQGdLLZMR9gW2TvH/olKHfN3X4cwUQcQlmQRUuEudq/Pvmz4MfjDZe2BsN0on+etF0/yHrF/Q==";

        public JwtSecurityToken CreateToken(string accessTokenToExchange)
        {
            return CreateToken(new Dictionary<string, object>
            {
                { "type", "embed" },
                { "wcn", "savpek01bi" },
                { "wid", "6273724f-a92d-4058-b137-a549414848af" },
                { "rid", "55a8e830-c77c-44b8-a1f0-47cd22782554" },
                { "scp", "Dataset.Read.All" },
                { "roles", "2b75c2b2-44f9-4ca3-8e0a-80c3aa1c4530" }
            }, 60 * 5);
        }

        private JwtSecurityToken CreateToken(Dictionary<string, object> claims, int expiresInSec)
        {
            var header = new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_powerBiAccessSecret)), SecurityAlgorithms.HmacSha256));

            DateTimeOffset now = DateTimeOffset.Now;

            var payload = new JwtPayload(
                issuer: "powerbi_exchange",
                claims: new List<Claim>(), 
                notBefore: now.UtcDateTime,
                audience: "powerbi",
                expires: now.UtcDateTime.AddSeconds(expiresInSec));

            claims.ToList().ForEach(c => payload.Add(c.Key, c.Value));

            return new JwtSecurityToken(header, payload);
        }
    }
}
