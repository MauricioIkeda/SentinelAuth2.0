using System.Reflection.Metadata;
using Generic.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Generic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class SentinelAuthControllerBase : ControllerBase
{
    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
        {
            return Ok();
        }
        
        return HandleError(result);
    }

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        
        return HandleError(result);
    }

    private IActionResult HandleError(Result result)
    {
        var problemDetails = new ProblemDetails
        {
            Detail = result.Message
        };
        
        return result.ErrorType switch
        {
            ErrorType.Validation => BadRequest(problemDetails),
            ErrorType.NotFound => NotFound(problemDetails),
            ErrorType.Conflict => Conflict(problemDetails),
            ErrorType.Unauthorized => Unauthorized(problemDetails),
            ErrorType.Forbidden => StatusCode(StatusCodes.Status403Forbidden, problemDetails),
            _ => StatusCode(StatusCodes.Status500InternalServerError, problemDetails)
        };
    }
}