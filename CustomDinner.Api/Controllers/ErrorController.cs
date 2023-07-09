using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace CustomDinner.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        const int status = StatusCodes.Status500InternalServerError;
        
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        return Problem(statusCode: status,
            title: exception?.Message ?? ReasonPhrases.GetReasonPhrase(status));
    }
}