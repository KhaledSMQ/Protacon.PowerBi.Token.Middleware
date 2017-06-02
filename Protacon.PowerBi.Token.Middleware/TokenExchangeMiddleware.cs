using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Protacon.PowerBi.Token.Middleware
{
    public class TokenExchangeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtTokenFactory _tokenFactory;

        public TokenExchangeMiddleware(RequestDelegate next, IJwtTokenFactory tokenFactory)
        {
            _next = next;
            _tokenFactory = tokenFactory;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.HasValue && httpContext.Request.Path.Value.StartsWith("/powerbi/v1/tokenexchange"))
            {
                httpContext.Response.StatusCode = 200;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(JObject.FromObject(new
                {
                    token = _tokenFactory.CreateToken("todo")
                }).ToString());

                return;
            }

            await _next(httpContext);
        }
    }
}
