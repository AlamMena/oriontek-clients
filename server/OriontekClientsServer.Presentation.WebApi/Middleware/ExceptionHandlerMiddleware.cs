using OriontekClientsServer.Domain.Exceptions;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace OriontekClientsServer.Presentation.WebApi.Middleware
{

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                await BuildResponse(context, ex.ErrorCode, "Error", ex.Message);
            }
            catch (Exception ex)
            {
                await BuildResponse(context, (int)HttpStatusCode.InternalServerError, "title", "errorMessage");
            }
        }
        private static async Task BuildResponse(HttpContext context, int code, string tittle, string errorMessage, object? details = null)
        {
            context.Response.ContentType = "application/problem+json";
            var stream = context.Response.Body;
            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

            context.Response.StatusCode = (int)code;

            await System.Text.Json.JsonSerializer.SerializeAsync(stream,
                new { status = code, message = errorMessage, title = tittle, traceId = traceId, details });

        }
    }
}
