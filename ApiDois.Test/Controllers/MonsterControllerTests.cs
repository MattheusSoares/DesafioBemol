using ApiDois.Controllers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static LibContract.MonsterService;

namespace ApiDois.Test.Controllers;

public class MonsterControllerTests
{
    private readonly MonsterController _controller;
    private readonly Mock<MonsterServiceClient> _mockClient;

    public MonsterControllerTests()
    {
        _mockClient = new Mock<MonsterServiceClient>();
        _controller = new MonsterController(_mockClient.Object);
    }

    [Fact]
    public async Task GetAsync_ReturnsOkResult_WithMonster()
    {
        // Arrange
        var monsterId = "test-id";
        var monsterResponse = new Monster();
        var monsterCall = new AsyncUnaryCall<Monster>(Task.FromResult(new Monster()), null, null, null, null);

        _mockClient.Setup(client => client.GetAsync(It.Is<MonsterLookupModel>(model => model.Id == monsterId), null, null, CancellationToken.None))
                   .Returns(monsterCall);

        // Act
        var result = await _controller.GetAsync(monsterId) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(monsterResponse, result.Value);
    }

    [Fact]
    public async Task GetListAsync_ReturnsOkResult_WithMonsterList()
    {
        // Arrange
        var monsterListResponse = new MonsterList(); // Assume MonsterList is a valid object
        var monsterListCall = new AsyncUnaryCall<MonsterList>(Task.FromResult(new MonsterList()), null, null, null, null);
        _mockClient.Setup(client => client.GetListAsync(It.IsAny<Empty>(), null, null, CancellationToken.None))
                   .Returns(monsterListCall);

        // Act
        var result = await _controller.GetListAsync() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(monsterListResponse, result.Value);
    }

    [Fact]
    public async Task InsertAsync_ReturnsOkResult_WithMonster()
    {
        // Arrange
        var newMonsterRequest = new NewMonsterRequest();
        var monsterResponse = new Monster();
        var monsterCall = new AsyncUnaryCall<Monster>(Task.FromResult(new Monster()), null, null, null, null);
        _mockClient.Setup(client => client.InsertAsync(newMonsterRequest, null, null, CancellationToken.None))
                   .Returns(monsterCall);

        // Act
        var result = await _controller.InsertAsync(newMonsterRequest) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(monsterResponse, result.Value);
    }
}
