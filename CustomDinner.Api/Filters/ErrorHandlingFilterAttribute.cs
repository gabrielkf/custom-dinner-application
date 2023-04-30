using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    private const string InternalErrorType = "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/500";
    public override void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Type = InternalErrorType,
            Instance = context.HttpContext.Request.Path,
            Status = StatusCodes.Status500InternalServerError,
            Detail = context.Exception.Message
        };
        
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}