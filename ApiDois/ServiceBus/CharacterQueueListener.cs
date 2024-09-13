using ApiDois.Infra.ServiceBus.Configuration;

namespace ApiDois.ServiceBus;

public class CharacterQueueListener : BackgroundService
{
    private readonly IServiceBusHandler _handler;

    public CharacterQueueListener(IServiceBusHandler handler)
    {
        _handler = handler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _handler.ConsumeAsync("character.queue");
    }
}