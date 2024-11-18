using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Middlewares;

public class GlobalExceptionHandler: IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails()
        {
            Status = 500,
            Title = "Фатальная ошибка на сервере",
            Detail = exception.Message
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}