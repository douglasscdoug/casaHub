using System.Diagnostics;
using System.Net;
using System.Text.Json;
using CasaHub.API.Responses;
using CasaHub.Application.Exceptions;

namespace CasaHub.API.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Erro não tratado durante a requisição. Path: {Path}",
                    context.Request.Path);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                TraceId = Activity.Current?.TraceId.ToString()
            };

            switch (exception)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    response.Status = context.Response.StatusCode;
                    response.Title = "Validation Error";
                    response.Message = validationException.Message;
                    response.Errors = validationException.Errors.Select(error => new ErrorDetail
                    {
                        Field = char.ToLowerInvariant(error.Field[0]) + error.Field.Substring(1),
                        Message = error.Message
                    });
                    break;


                case BusinessException businessException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    response.Status = context.Response.StatusCode;
                    response.Title = "Business Error";
                    response.Message = businessException.Message;
                    break;


                case NotFoundException notFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;

                    response.Status = context.Response.StatusCode;
                    response.Title = "Not Found";
                    response.Message = notFoundException.Message;
                    break;


                case UnauthorizedException unauthorizedException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    response.Status = context.Response.StatusCode;
                    response.Title = "Unauthorized";
                    response.Message = unauthorizedException.Message;
                    break;

                case PersistenceException persistenceException:
                    context.Response.StatusCode =
                        StatusCodes.Status500InternalServerError;

                    response.Status = context.Response.StatusCode;
                    response.Title = "Persistence Error";
                    response.Message = persistenceException.Message;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    response.Status = context.Response.StatusCode;
                    response.Title = "Internal Server Error";
                    response.Message = "Ocorreu um erro inesperado.";
                    break;
            }

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}