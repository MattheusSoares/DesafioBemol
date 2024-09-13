using ApiUm.Domain.Characters.Handlers;
using ApiUm.Domain.Characters.Interfaces.Adapters;
using ApiUm.Domain.Characters.Interfaces.Handlers;
using ApiUm.Domain.Characters.Interfaces.Repositories;
using ApiUm.Domain.Shared.Settings;
using ApiUm.Domain.Users.Handlers;
using ApiUm.Domain.Users.Interfaces.Handlers;
using ApiUm.Filters;
using ApiUm.Infra.Data.Characters.Repositories;
using ApiUm.Infra.Data.DataContexts;
using ApiUm.Infra.Data.Settings;
using ApiUm.Infra.ServiceBus.Characters.Adapters;
using ApiUm.Infra.ServiceBus.Configuration;
using ApiUm.Infra.ServiceBus.Settings;
using ApiUm.Swagger;
using Microsoft.OpenApi.Models;

namespace ApiUm.Extensions;

public static class IoC
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        //Add Grpc Server
        services.AddGrpc();

        //Add Authentication Filter
        services.AddScoped<AuthenticationFilter>();

        //Add Swagger
        services.AddSToSwagger();

        //Add Database Settings
        DatabaseSettings databaseSettings = new();
        configuration.GetSection("CosmosDb").Bind(databaseSettings);
        services.AddSingleton(databaseSettings);

        //Add Service Bus Settings
        ServiceBusSettings serviceBusSettings = new();
        configuration.GetSection("ServiceBus").Bind(serviceBusSettings);
        services.AddSingleton(serviceBusSettings);

        //Add Authentication Settings
        AuthenticationSettings authenticationSettings = new();
        configuration.GetSection("Authentication").Bind(authenticationSettings);
        services.AddSingleton(authenticationSettings);

        //Add DataContext
        services.AddScoped<IDataContext, DataContext>();
        //Add ServiceBus Configuration 
        services.AddScoped<IServiceBusHandler, ServiceBusHandler>();
        //Add Repository
        services.AddScoped<ICharacterRepository, CharacterRepository>();
        //Add QueueAdapter
        services.AddScoped<ICharacterAdapter, CharacterAdapter>();
        //Add Handlers
        services.AddScoped<ICharacterHandler, CharacterHandler>();
        services.AddScoped<IUserHandler, UserHandler>();

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
                    Title = "Character API",
                    Description = "Character API",
                });

            c.OperationFilter<AdditionalHeaderSwaggerFilter>();
        });
    }
}
