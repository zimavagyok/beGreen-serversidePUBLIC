using beGreen.Model.Middleware;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace beGreen.WebApplication.exceptionResponseMiddleware
{
    public class HttpStatusCodeExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpStatusCodeExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.Clear(); //<-possible Angular CORS error
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = ex.ContentType;

                ProblemDetails responseBody = new ProblemDetails(ex.Message, ex.StatusCode, "Request error");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(responseBody));

                return;
            }
        }
    }
}
