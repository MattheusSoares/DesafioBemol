using ApiUm.Grpc;
using Google.Protobuf.WellKnownTypes;
using LibContract;
using Moq;

namespace ApiUm.Test.Grpc;

public class MonsterGrpcServiceTests
{
    private readonly Mock<MonsterGrpcService> _serviceMock;

    public MonsterGrpcServiceTests()
    {
        _serviceMock = new Mock<MonsterGrpcService>();
    }

    [Fact]
    public async Task Get_ReturnsMonster_WhenMonsterExists()
    {
        // Arrange
        var monsterId = "1";
        var expectedMonster = new Monster { Id = monsterId, Name = "Dragon", Health = 100, IsLegendary = true };
        _serviceMock.Setup(s => s.Get(It.Is<MonsterLookupModel>(r => r.Id == monsterId), null))
            .ReturnsAsync(expectedMonster);

        var request = new MonsterLookupModel { Id = monsterId };

        // Act
        var result = await _serviceMock.Object.Get(request, null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedMonster.Id, result.Id);
        Assert.Equal(expectedMonster.Name, result.Name);
    }

    [Fact]
    public async Task Get_ReturnsNull_WhenMonsterDoesNotExist()
    {
        // Arrange
        var nonExistingId = "NonExistingId";
        _serviceMock.Setup(s => s.Get(It.Is<MonsterLookupModel>(r => r.Id == nonExistingId), null))
            .ReturnsAsync((Monster)null);

        var request = new MonsterLookupModel { Id = nonExistingId };

        // Act
        var result = await _serviceMock.Object.Get(request, null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_ReturnsAllMonsters()
    {
        // Arrange
        var monster1 = new Monster { Id = "1", Name = "Dragon", Health = 100, IsLegendary = true };
        var monster2 = new Monster { Id = "2", Name = "Goblin", Health = 50, IsLegendary = false };
        var monsterList = new MonsterList();
        monsterList.Monsters.Add(monster1);
        monsterList.Monsters.Add(monster2);

        _serviceMock.Setup(s => s.GetList(It.IsAny<Empty>(), null))
            .ReturnsAsync(monsterList);

        var request = new Empty();

        // Act
        var result = await _serviceMock.Object.GetList(request, null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Monsters.Count);
        Assert.Contains(result.Monsters, m => m.Id == monster1.Id);
        Assert.Contains(result.Monsters, m => m.Id == monster2.Id);
    }

    [Fact]
    public async Task Insert_AddsMonsterToList()
    {
        // Arrange
        var request = new NewMonsterRequest { Name = "Troll", Health = 75, IsLegendary = false };
        var newMonster = new Monster
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Health = request.Health,
            IsLegendary = request.IsLegendary
        };

        _serviceMock.Setup(s => s.Insert(request, null))
            .ReturnsAsync(newMonster);

        // Act
        var result = await _serviceMock.Object.Insert(request, null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(request.Name, result.Name);
        Assert.Equal(request.Health, result.Health);
        Assert.Equal(request.IsLegendary, result.IsLegendary);
    }
}
