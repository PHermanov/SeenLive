using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SeenLive.Infrastructure;
using SeenLive.Users;

namespace SeenLive.Api.Controllers;

public class BaseController
    : ControllerBase
{
    public BaseController(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        var userName = httpContextAccessor.HttpContext?.User.Identity?.Name;

        if (userName != null)
        {
            AuthenticatedUser = userManager.FindByNameAsync(userName).Result;
        }
    }

    public User? AuthenticatedUser { get; }

    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult ProcessError(Error error)
        => error.Type switch
        {
            ErrorType.NotFound => Problem(error.Message, statusCode: StatusCodes.Status404NotFound),
            ErrorType.Unauthorized => Unauthorized(error.Message),
            ErrorType.BadRequest => Problem(error.Message, statusCode: StatusCodes.Status400BadRequest),
            ErrorType.InternalError => Problem(error.Message),
            ErrorType.Validation => CreateValidationError(error),
            _ => Problem()
        };

    private ActionResult CreateValidationError(Error error)
    {
        ModelState.AddModelError(error.Field, error.Message);
        return ValidationProblem(ModelState);
    }
}