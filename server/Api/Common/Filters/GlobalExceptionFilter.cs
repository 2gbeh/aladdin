using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using server.Api.Common.Interfaces;

namespace server.Api.Common.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var response = new IApiResponse<object>(
            Result: null!,
            Success: false,
            Message: context.Exception.Message,
            ErrorCode: context.Exception.GetType().Name
        );

        context.Result = new ObjectResult(response)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
