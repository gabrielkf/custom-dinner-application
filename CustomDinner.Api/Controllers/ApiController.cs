using CustomDinner.Api.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomDinner.Api.Controllers;

public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (!errors.Any())
        {
            return Problem();
        }
        
        if (TryGetValidationErrorsModelStateDictionary(errors, out var modelStateDictionary))
        {
            return ValidationProblem(modelStateDictionary!);
        }
        
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        
        return SelectedProblem(errors);
    }

    private static bool TryGetValidationErrorsModelStateDictionary(List<Error> errors,
        out ModelStateDictionary? modelStateDictionary)
    {
        if (errors.All(err => err.Type == ErrorType.Validation))
        {
            modelStateDictionary = null;
            return false;
        }
        
        modelStateDictionary = new ModelStateDictionary();

        foreach (var err in errors)
        {
            modelStateDictionary.AddModelError(
                err.Code,
                err.Description);
        }

        return true;
    }

    private IActionResult SelectedProblem(List<Error> errors)
    {
        var firstError = errors.FirstOrDefault();

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode,
            title: firstError.Description);
    }
}