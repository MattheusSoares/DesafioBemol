namespace ApiDois.Infra.ServiceBus.Configuration;

public interface IServiceBusHandler
{
    Task ConsumeAsync(string queueName);
}
