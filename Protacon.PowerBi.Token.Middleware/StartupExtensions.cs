using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Protacon.PowerBi.Token.Middleware
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseBiTokenExchange(this IApplicationBuilder app)
        {
            app.UseMiddleware<TokenExchangeMiddleware>();
            return app;
        }

        public static IServiceCollection AddBiTokenExchange(this IServiceCollection services)
        {
            services.AddTransient<IJwtTokenFactory, TokenFactory>();
            return services;
        }
}
}
