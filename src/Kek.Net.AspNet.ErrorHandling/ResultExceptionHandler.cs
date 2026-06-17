using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kek.Net.AspNet.ErrorHandling;

public class ResultExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetail = new ProblemDetails()
        {
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Title = exception.GetType().Name,
            Instance = exception.Source,
        };
        
        await httpContext.Response.WriteAsJsonAsync(problemDetail, cancellationToken);
        
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/problem+json; charset=utf-8";
        
        return true;
    }

}