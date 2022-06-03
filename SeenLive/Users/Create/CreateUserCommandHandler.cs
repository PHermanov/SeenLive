using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SeenLive.Infrastructure;

namespace SeenLive.Users.Create;

internal class CreateUserCommandHandler
    : HandlerBase, IRequestHandler<CreateUserCommand, IHandlerResult<string>>
{

    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateUserCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IHandlerResult<string>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByNameAsync(command.Username);
        if (userExists != null)
        {
            return BadRequest<string>("User with given name already exists");
        }

        var user = new User
        {
            Email = command.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = command.Username
        };

        var result = await _userManager.CreateAsync(user, command.Password);

        return result.Succeeded
            ? Data("User created successfully!")
            : InternalError<string>(result.Errors.FirstOrDefault()?.Description ?? "Internal Server Error");
    }
}

