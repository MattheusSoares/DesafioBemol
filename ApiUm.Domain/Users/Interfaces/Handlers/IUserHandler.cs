using ApiUm.Domain.Shared.Commands.Result;
using ApiUm.Domain.Users.Commands.Input;

namespace ApiUm.Domain.Users.Interfaces.Handlers;

public interface IUserHandler
{
    CommandResult Login(UserLoginCommand command);

    bool ValidateToken(string jwtToken);
}
