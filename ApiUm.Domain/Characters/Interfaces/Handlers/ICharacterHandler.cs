using ApiUm.Domain.Characters.Commands.Input;
using ApiUm.Domain.Shared.Commands.Result;

namespace ApiUm.Domain.Characters.Interfaces.Handlers;

public interface ICharacterHandler
{
    Task<CommandResult> InsertAsync(CharacterAddCommand command);
}
