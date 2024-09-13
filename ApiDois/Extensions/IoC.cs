using ApiDois.Grpc;
using ApiDois.Infra.ServiceBus.Configuration;
using ApiDois.Infra.ServiceBus.Settings;
using ApiDois.ServiceBus;
using Microsoft.OpenApi.Models;
using static LibContract.MonsterService;

namespace ApiDois.Extensions;

public static class IoC
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        //Add Swagger
        services.AddSToSwagger();

        //Add Service Bus Settings
        ServiceBusSettings serviceBusSettings = new();
        configuration.GetSection("ServiceBus").Bind(serviceBusSettings);
        services.AddSingleton(serviceBusSettings);

        //Add Grpc Settings
        GrpcSettings grpcSettings = new();
        configuration.GetSection("Grpc").Bind(grpcSettings);
        services.AddSingleton(grpcSettings);

        //Add Grpc Client
        services.AddGrpcClient<MonsterServiceClient>(client => { client.Address = new Uri(grpcSettings.GrpcUri); });

        //Add ServiceBus Configuration 
        services.AddSingleton<IServiceBusHandler, ServiceBusHandler>();

        //Add Queue Listener
        services.AddHostedService<CharacterQueueListener>();

        return services;
    }

    private static IServiceCollection AddSToSwagger(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Monster API",
                    Description = "Monster API",
                });
        });
    }
}

