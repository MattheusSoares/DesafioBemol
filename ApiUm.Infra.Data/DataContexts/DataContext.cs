using ApiUm.Infra.Data.Settings;
using Microsoft.Azure.Cosmos;

namespace ApiUm.Infra.Data.DataContexts;

public class DataContext : IDataContext
{
    private CosmosClient Client { get; }
    private Database Database { get; }

    public DataContext(DatabaseSettings settings)
    {
        Client = new CosmosClient(settings.EndpointUri, settings.PrimaryKey);
        Database = Client.GetDatabase(settings.DatabaseId);
    }

    public void Dispose()
    {
        Client?.Dispose();
    }

    public Container GetContainer(string containerId)
    {
        return Database.GetContainer(containerId);
    }
}