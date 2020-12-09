using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
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
            if (UpdateContext(context)) await _next(context);
        }

        private static bool UpdateContext(HttpContext context)
        {
            if (context.Request.Path.ToString().Contains("favicon.ico")) return false;

            var processedUrl = context.Request.Path
                .ToUriComponent()
                .Split('/')
                .Where(part => !string.IsNullOrEmpty(part))
                .Skip(1);

            var queryString = string.IsNullOrEmpty(context.Request.QueryString.ToString())
                ? string.Empty
                : context.Request.QueryString.ToString().Substring(1);

            var query = new Dictionary<string, StringValues>
            {
                {"Query",  Uri.UnescapeDataString(queryString)},
                {"Route", string.Join(".", processedUrl)}
            };

            context.Request.Path = "/api";
            context.Request.Query = new QueryCollection(query);
            return true;
        }
    }
}
