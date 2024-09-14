using ApiUm.Domain.Characters.Dtos;
using ApiUm.Domain.Characters.Entities;
using ApiUm.Infra.ServiceBus.Characters.Adapters;
using ApiUm.Infra.ServiceBus.Configuration;
using Moq;

namespace ApiUm.Infra.ServiceBus.Test.Characters.Adapters;

public class CharacterAdapterTests
{
    private readonly Mock<IServiceBusHandler> _mockHandler;
    private readonly CharacterAdapter _adapter;

    public CharacterAdapterTests()
    {
        // Arrange
        _mockHandler = new Mock<IServiceBusHandler>();
        _adapter = new CharacterAdapter(_mockHandler.Object);
    }

    [Fact]
    public async Task SendAsync_ShouldCallSendMessageAsync_WithCorrectParameters()
    {
        // Arrange
        var character = new Character(Guid.NewGuid(), "Test Character", "Elf", "Wizard", 5, "Noble", 3, 10, 14, 12, 18, 16, 13);

        var characterDto = new CharacterQueueDto(character);

        var queueName = "character.queue";

        // Act
        await _adapter.SendAsync(characterDto);

        // Assert
        _mockHandler.Verify(handler => handler.SendMessageAsync(queueName, characterDto), Times.Once);
    }
}
