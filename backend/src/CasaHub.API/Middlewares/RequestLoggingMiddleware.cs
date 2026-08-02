using System.Diagnostics;

namespace CasaHub.API.Middlewares
{
    public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var traceId = Activity.Current?.TraceId.ToString()
                          ?? Guid.NewGuid().ToString();

            using (logger.BeginScope(new Dictionary<string, object>
            {
                ["TraceId"] = traceId,
                ["Path"] = context.Request.Path,
                ["Method"] = context.Request.Method
            }))
            {
                logger.LogInformation(
                    "Request iniciada");

                await next(context);

                stopwatch.Stop();

                logger.LogInformation(
                    "Request finalizada. StatusCode: {StatusCode} Tempo: {ElapsedMs}ms",
                    context.Response.StatusCode,
                    stopwatch.ElapsedMilliseconds);
            }
        }
    }
}