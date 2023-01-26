using CustomerAPI.Models;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace CustomerApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status = 0;
        var stackTrace = string.Empty;
        string message;

        var exceptionType = exception.GetType();

        if (exceptionType == typeof(BadRequestException))
        {
            status = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(NotFoundException))
        {
            status = HttpStatusCode.NotFound;
        }
        else if (exceptionType == typeof(CustomerAPI.Models.UnauthorizedAccessException))
        {
            status = HttpStatusCode.Unauthorized;          
        }
        else if (exceptionType == typeof(InternalServerErrorException))
        {
            status = HttpStatusCode.InternalServerError;
        }
        message = exception.Message;
        stackTrace = exception.StackTrace;

        _logger.LogError($"{exception} Request failed with Status Code {status}");

        var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        await context.Response.WriteAsync(exceptionResult);
    }
}