using Microsoft.Azure.Cosmos;

namespace ApiUm.Infra.Data.DataContexts;

public interface IDataContext : IDisposable
{
    Container GetContainer(string containerId);
}
