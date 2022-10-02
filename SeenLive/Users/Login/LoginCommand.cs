using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Users.Login;

public class LoginCommand
    : IRequest<IHandlerResult<TokenViewModel>>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}