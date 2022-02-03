using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Infrastructure;
using SeenLive.Users;

namespace SeenLive.Api.Controllers;

public class BaseController
    : ControllerBase
{
    public BaseController(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        AuthenticatedUser = userManager.FindByNameAsync(httpContextAccessor.HttpContext?.User.Identity?.Name).Result;
    }

    public User? AuthenticatedUser { get; }


    [ApiExplorerSettings(IgnoreApi = true)]
    public ActionResult ProcessError(Error error)
        => error.Type switch
        {
            ErrorType.NotFound => NotFound(error.Message),
            ErrorType.Unauthorized => Unauthorized(error.Message),
            ErrorType.BadRequest => BadRequest(error.Message),
            ErrorType.InternalError => Problem(error.Message),
            _ => Problem()
        };
}
