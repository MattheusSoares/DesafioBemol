using ApiUm.Domain.Characters.Commands.Result;
using ApiUm.Domain.Characters.Entities;
using ApiUm.Domain.Characters.Interfaces.Repositories;
using ApiUm.Infra.Data.DataContexts;
using Microsoft.Azure.Cosmos;

namespace ApiUm.Infra.Data.Characters.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly Container _container;

    public CharacterRepository(IDataContext context)
    {
        _container = context.GetContainer(nameof(Character));
    }

    public async Task InsertAsync(Character character) =>
        await _container.CreateItemAsync(character, new PartitionKey(character.PartitionKey));

    public async Task<List<CharacterCommandResult>> ListAsync()
    {
        var sqlQueryText = "SELECT * FROM c";
        var queryDefinition = new QueryDefinition(sqlQueryText);
        var queryResultSetIterator = _container.GetItemQueryIterator<CharacterCommandResult>(queryDefinition);

        var characters = new List<CharacterCommandResult>();
        while (queryResultSetIterator.HasMoreResults)
        {
            var currentResultSet = await queryResultSetIterator.ReadNextAsync();
            foreach (var character in currentResultSet)
            {
                characters.Add(character);
            }
        }

        return characters;
    }
}
