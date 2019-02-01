using Microsoft.Extensions.DependencyInjection;

namespace Utn.PWA.Api.Middlewares
{
    public static class CorsMiddleware
    {
        public static IServiceCollection AddPoliciesCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return services;
        }
    }
}
