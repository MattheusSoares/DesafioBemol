using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibContract;

namespace ApiUm.Grpc;

public class MonsterGrpcService : MonsterService.MonsterServiceBase
{
    private static List<Monster> MonsterList = new List<Monster>();

    public override Task<Monster> Get(MonsterLookupModel request, ServerCallContext context)
    {
        var monster = MonsterList.FirstOrDefault(m => m.Id.Equals(request.Id));

        return Task.FromResult(monster);
    }

    public override Task<MonsterList> GetList(Empty request, ServerCallContext context)
    {
        var list = new MonsterList();

        list.Monsters.AddRange(MonsterList);
        return Task.FromResult(list);
    }

    public override Task<Monster> Insert(NewMonsterRequest request, ServerCallContext context)
    {
        var monster = new Monster()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Health = request.Health,
            IsLegendary = request.IsLegendary
        };

        MonsterList.Add(monster);

        return Task.FromResult(monster);
    }
}

