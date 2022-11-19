using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Product.API.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
   
        public async Task Invoke(HttpContext httpContext)
        {

            var watch = Stopwatch.StartNew();

            await _next.Invoke(httpContext);
            watch.Stop();
            if (watch.ElapsedMilliseconds > 500)
            {
                _logger.LogTrace("Duration:{duration}ms, Request path:{path},Request Method:{method}",
                    watch.ElapsedMilliseconds, httpContext.Request.Path, httpContext.Request.Method);
            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}