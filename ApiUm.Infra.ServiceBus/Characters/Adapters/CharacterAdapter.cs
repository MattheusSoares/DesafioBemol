using ApiUm.Domain.Characters.Dtos;
using ApiUm.Domain.Characters.Interfaces.Adapters;
using ApiUm.Infra.ServiceBus.Configuration;

namespace ApiUm.Infra.ServiceBus.Characters.Adapters;

public class CharacterAdapter : ICharacterAdapter
{
    private readonly IServiceBusHandler _handler;

    public CharacterAdapter(IServiceBusHandler handler)
    {
        _handler = handler;
    }

    public async Task SendAsync(CharacterQueueDto character)
    {
        var queueName = "character.queue";
        await _handler.SendMessageAsync(queueName, character);
    }
}
