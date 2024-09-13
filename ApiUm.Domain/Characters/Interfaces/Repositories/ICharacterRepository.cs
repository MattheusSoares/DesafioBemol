using ApiUm.Domain.Characters.Commands.Result;
using ApiUm.Domain.Characters.Entities;

namespace ApiUm.Domain.Characters.Interfaces.Repositories;

public interface ICharacterRepository
{
    Task InsertAsync(Character character);
    Task<List<CharacterCommandResult>> ListAsync();
}
