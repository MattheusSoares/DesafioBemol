using ApiUm.Domain.Characters.Dtos;

namespace ApiUm.Domain.Characters.Interfaces.Adapters;

public interface ICharacterAdapter
{
    Task SendAsync(CharacterQueueDto character);
}
