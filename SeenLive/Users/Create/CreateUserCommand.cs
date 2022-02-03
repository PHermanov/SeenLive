using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Users.Create;

public class CreateUserCommand
    : IRequest<IHandlerResult<string>>
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}