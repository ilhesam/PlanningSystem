using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API;

public class ResultFilter : IAsyncActionFilter
{
    protected readonly IUserContext UserContext;

    public ResultFilter(IUserContext userContext)
    {
        UserContext = userContext;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        var actionContext = await next();
        stopwatch.Stop();

        var response = new ApiResponse
        {
            TraceIdentifier = context.HttpContext.TraceIdentifier,
            Duration = stopwatch.ElapsedMilliseconds,
            Time = DateTime.UtcNow,
            UserName = UserContext.UserName
        };

        if (actionContext.Exception != null)
        {
            response.Errors = new List<ApiError> { new(actionContext.Exception) };
            response.Succeeded = false;

            actionContext.Result = new ObjectResult(response);
            actionContext.ExceptionHandled = true;

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
        else if (actionContext.Result is ObjectResult objectResult)
        {
            response.Result = objectResult.Value;
            response.Succeeded = true;

            actionContext.Result = new ObjectResult(response);

            context.HttpContext.Response.StatusCode = objectResult.StatusCode ?? StatusCodes.Status200OK;
        }
    }
}