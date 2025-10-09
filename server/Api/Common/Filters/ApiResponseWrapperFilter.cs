using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using server.Api.Common.Interfaces;

namespace server.Api.Common.Filters;

public class ApiResponseWrapperFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult && objectResult.Value != null)
        {
            // Don't wrap if already wrapped
            var resultType = objectResult.Value.GetType();
            if (resultType.IsGenericType && 
                resultType.GetGenericTypeDefinition() == typeof(IApiResponse<>))
            {
                return;
            }

            // Wrap the result
            objectResult.Value = new IApiResponse<object>(
                Result: objectResult.Value,
                Success: true
            );
        }
        else if (context.Exception == null && context.Result is OkResult)
        {
            // Handle void returns
            context.Result = new OkObjectResult(new IApiResponse<object>(
                Result: new { },
                Success: true
            ));
        }
    }
}
