namespace ApiUm.Infra.ServiceBus.Configuration;

public interface IServiceBusHandler
{
    Task SendMessageAsync(string queue, string message);
    Task SendMessageAsync<T>(string queue, T message);
}
