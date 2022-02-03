using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeenLive.Users;
using SeenLive.Users.Create;
using SeenLive.Users.Login;

namespace SeenLive.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController
    : BaseController
{
    private readonly IMediator _mediator;

    public AuthenticateController(IMediator mediator, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        : base(userManager, httpContextAccessor)
            => _mediator = mediator;

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Login([FromBody] LoginCommand command)
    {
        var response = await _mediator.Send(command);

        return response.Success
            ? Ok(response)
            : ProcessError(response.Error!);
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        var response = await _mediator.Send(command);

        return response.Success
            ? Ok(response)
            : ProcessError(response.Error!);
    }
}