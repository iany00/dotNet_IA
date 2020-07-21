using System;
using System.Threading.Tasks;
using CarStore.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace CarStore.API.Middleware
{
    public class RequestLogger
    {
        private readonly RequestDelegate next;

        public RequestLogger(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ISimpleLogger simpleLogger)
        {
            var date = DateTime.Now;
            simpleLogger.LogInfo($"Handling request: {context.Request.Method} {context.Request.Path}");

            await this.next.Invoke(context);

            simpleLogger.LogInfo($"Finished handling request. Milliseconds: {(DateTime.Now - date).TotalMilliseconds}");
        }
    }
}
