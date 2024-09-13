using ApiUm.Domain.Characters.Commands.Input;
using ApiUm.Domain.Characters.Dtos;
using ApiUm.Domain.Characters.Interfaces.Adapters;
using ApiUm.Domain.Characters.Interfaces.Handlers;
using ApiUm.Domain.Characters.Interfaces.Repositories;
using ApiUm.Domain.Shared.Commands.Result;
using Microsoft.AspNetCore.Http;

namespace ApiUm.Domain.Characters.Handlers;

public class CharacterHandler : ICharacterHandler
{
    private readonly ICharacterRepository _repository;
    private readonly ICharacterAdapter _adapter;

    public CharacterHandler(ICharacterRepository repository,
                            ICharacterAdapter adapter)
    {
        _repository = repository;
        _adapter = adapter;
    }

    public async Task<CommandResult> InsertAsync(CharacterAddCommand command)
    {
        if (command == null)
            return new CommandResult(StatusCodes.Status400BadRequest, "Invalid parameters", "Input parameters", "Input parameters are null");

        if (!command.IsValid())
            return new CommandResult(StatusCodes.Status422UnprocessableEntity, "Invalid parameters", command.Notifications);

        var character = command.MapToCharacter();

        if (character.Invalid)
            return new CommandResult(StatusCodes.Status422UnprocessableEntity, "Inconsistencies in the data", character.Notifications);

        await _repository.InsertAsync(character);

        await _adapter.SendAsync(new CharacterQueueDto(character));

        var resultData = character.MapToCharacterCommandResult();

        return new CommandResult(StatusCodes.Status201Created, "Character successfully inserted!", resultData);
    }
}
