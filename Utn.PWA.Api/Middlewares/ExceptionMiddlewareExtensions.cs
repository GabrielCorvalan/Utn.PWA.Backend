using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Utn.PWA.Helpers;

namespace Utn.PWA.Api.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
 
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if(exception != null)
                    {
 
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(exception));
                    }
                });
            });
        }
    }
}