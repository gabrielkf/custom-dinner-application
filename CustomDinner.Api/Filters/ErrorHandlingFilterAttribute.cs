using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Type = "https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/500",
            Instance = context.HttpContext.Request.Path,
            Status = StatusCodes.Status500InternalServerError,
            Detail = context.Exception.Message
        };
        
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}