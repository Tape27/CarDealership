using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using Application.Common.Exceptions;
using FluentValidation;

namespace CarDealership.Web.Middleware
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
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex);
            }
        }

        private Task HandlerExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var error = string.Empty;

            switch (ex)
            {
                case ValidationException validEx:
                    code = HttpStatusCode.BadRequest;
                    error = JsonSerializer.Serialize(validEx.Errors);
                    break;
                case NotFoundException NotFoundEx:
                    code = HttpStatusCode.NotFound;
                    error = NotFoundEx.Message;
                    break;
                case AuthenticationException authEx:
                    code = HttpStatusCode.Unauthorized;
                    error = authEx.Message;
                    break;
                default:
                    error = "The server cannot process your request at the moment!";
                    break;

            }

            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(error);
        }
    }
}
