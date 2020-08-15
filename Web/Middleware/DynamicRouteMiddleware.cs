using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Middleware
{
    public class DynamicRouteMiddleware
    {
        private readonly RequestDelegate _next;

        public DynamicRouteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            UpdateContext(context);
            await _next(context);
        }

        private static void UpdateContext(HttpContext context)
        {
            var splitedUrl = context.Request.Path
                .ToUriComponent()
                .Split('/')
                .Where(part => !string.IsNullOrEmpty(part))
                .Skip(1);

            var query = new Dictionary<string, StringValues>
            {
                {"Query", context.Request.QueryString.ToString()},
                {"Route", string.Join(".", splitedUrl)}
            };

            context.Request.Path = "/api";
            context.Request.Query = new QueryCollection(query);
        }
    }
}
