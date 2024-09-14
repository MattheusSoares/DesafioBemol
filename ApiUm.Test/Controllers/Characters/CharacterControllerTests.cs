using ApiUm.Controllers.Characters;
using ApiUm.Domain.Characters.Commands.Input;
using ApiUm.Domain.Characters.Commands.Result;
using ApiUm.Domain.Characters.Interfaces.Handlers;
using ApiUm.Domain.Characters.Interfaces.Repositories;
using ApiUm.Domain.Shared.Commands.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiUm.Test.Controllers.Characters;

public class CharacterControllerTests
{
    private readonly Mock<ICharacterRepository> _mockRepository;
    private readonly Mock<ICharacterHandler> _mockHandler;
    private readonly CharacterController _controller;

    public CharacterControllerTests()
    {
        _mockRepository = new Mock<ICharacterRepository>();
        _mockHandler = new Mock<ICharacterHandler>();
        _controller = new CharacterController(_mockRepository.Object, _mockHandler.Object);
    }

    [Fact]
    public async Task CharactersAsync_AddCharacter_ReturnsCreated()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
        };

        var result = new CommandResult(
            StatusCodes.Status201Created,
            "Character created successfully",
            new CharacterCommandResult(Guid.NewGuid(), "John Doe", "Human", "Warrior", 5, "Background", 2, 10, 12, 14, 16, 18, 20)
        );

        _mockHandler.Setup(h => h.InsertAsync(command))
            .ReturnsAsync(result);

        // Act
        var response = await _controller.CharactersAsync(command);

        // Assert
        var actionResult = Assert.IsType<ObjectResult>(response);
        Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
    }

    [Fact]
    public async Task CharactersAsync_AddCharacter_ReturnsBadRequest()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
        };

        var result = new CommandResult(
            StatusCodes.Status400BadRequest,
            "Bad Request",
            "PropertyName",
            "Property error message"
        );

        _mockHandler.Setup(h => h.InsertAsync(command))
            .ReturnsAsync(result);

        // Act
        var response = await _controller.CharactersAsync(command);

        // Assert
        var actionResult = Assert.IsType<ObjectResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
    }

    [Fact]
    public async Task CharactersAsync_ListCharacters_ReturnsOk()
    {
        // Arrange
        var characters = new List<CharacterCommandResult>
        {
            new CharacterCommandResult(Guid.NewGuid(), "John Doe", "Human", "Warrior", 5, "Background", 2, 10, 12, 14, 16, 18, 20)
        };

        _mockRepository.Setup(r => r.ListAsync())
            .ReturnsAsync(characters);

        // Act
        var response = await _controller.CharactersAsync();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(response);
        var returnedCharacters = Assert.IsType<List<CharacterCommandResult>>(actionResult.Value);
        Assert.Equal(characters.Count, returnedCharacters.Count);
    }
}