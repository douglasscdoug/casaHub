using CasaHub.API.Middlewares;

namespace CasaHub.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}