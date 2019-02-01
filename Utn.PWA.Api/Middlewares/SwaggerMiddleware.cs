using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Utn.PWA.Api.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API UTN", Version = "v1" });
            });

            return services;
        }
    }
}
