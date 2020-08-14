using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Web.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _log;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _log.LogInformation(context.Request.Path.Value);
                await _next(context);
            }
            catch (Exception ex)
            {
                _log.LogError($"Something went wrong: {ex.Message}");
            }
        }
    }
}
