using Microsoft.AspNetCore.Http;
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
            var url = context.Request.Path
                .ToUriComponent()
                .Split('/')
                .Where(part => !string.IsNullOrEmpty(part))
                .Skip(1);

            var path = string.Join(".", url);
            context.Request.Path = $"/api/{path}";

            await _next(context);
        }
    }
}
