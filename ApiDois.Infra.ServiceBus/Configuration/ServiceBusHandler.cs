using ApiDois.Infra.ServiceBus.Settings;
using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace ApiDois.Infra.ServiceBus.Configuration;

public class ServiceBusHandler : IServiceBusHandler
{
    private string ConnectionString { get; }

    public ServiceBusHandler(ServiceBusSettings settings)
    {
        ConnectionString = settings.ConnectionString;
    }

    public async Task ConsumeAsync(string queueName)
    {
        var client = new ServiceBusClient(ConnectionString);
        var processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;

        await processor.StartProcessingAsync();

        await Task.Delay(Timeout.Infinite);

        await processor.StopProcessingAsync();
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        var body = args.Message.Body.ToString();

        PrintMessage(body);

        await args.CompleteMessageAsync(args.Message);
    }

    private static void PrintMessage(string message)
    {
        Console.WriteLine("=========================================================");
        Console.WriteLine("================== Consumindo Mensagem ==================");
        Console.WriteLine("=========================================================");
        Console.WriteLine(FormatJson(message));
        Console.WriteLine();
        Console.WriteLine();
    }

    private static string FormatJson(string jsonString)
    {
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonString);
        var options = new JsonSerializerOptions { WriteIndented = true };

        return JsonSerializer.Serialize(jsonElement, options);
    }


    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        return Task.CompletedTask;
    }
}
