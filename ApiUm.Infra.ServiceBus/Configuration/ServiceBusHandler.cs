using ApiUm.Infra.ServiceBus.Settings;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using System.Text.Json;

namespace ApiUm.Infra.ServiceBus.Configuration;

public class ServiceBusHandler : IServiceBusHandler
{
    private string ConnectionString { get; }

    public ServiceBusHandler(ServiceBusSettings settings)
    {
        ConnectionString = settings.ConnectionString;
    }

    public async Task SendMessageAsync(string queue, string message)
    {
        await CreateQueueIfDoesntExists(queue);

        await using var client = new ServiceBusClient(ConnectionString);
        var sender = client.CreateSender(queue);

        var serviceBusMessage = new ServiceBusMessage(message);
        await sender.SendMessageAsync(serviceBusMessage);
    }

    public async Task SendMessageAsync<T>(string queue, T message)
    {
        var messageAsJson = JsonSerializer.Serialize(message);
        await SendMessageAsync(queue, messageAsJson);
    }

    private async Task CreateQueueIfDoesntExists(string queue)
    {
        var adminClient = new ServiceBusAdministrationClient(ConnectionString);

        if (!await adminClient.QueueExistsAsync(queue))
            await adminClient.CreateQueueAsync(queue);
    }
}
