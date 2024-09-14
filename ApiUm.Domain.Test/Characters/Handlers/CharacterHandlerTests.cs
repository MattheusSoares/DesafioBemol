using ApiUm.Domain.Characters.Commands.Input;
using ApiUm.Domain.Characters.Handlers;
using ApiUm.Domain.Characters.Interfaces.Adapters;
using ApiUm.Domain.Characters.Interfaces.Repositories;
using ApiUm.Domain.Characters.Validations;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ApiUm.Domain.Test.Characters.Handlers;

public class CharacterHandlerTests
{
    private readonly Mock<ICharacterRepository> _mockRepository;
    private readonly Mock<ICharacterAdapter> _mockAdapter;
    private readonly Mock<CharacterValidations> _mockValidations;
    private readonly CharacterHandler _characterHandler;

    public CharacterHandlerTests()
    {
        _mockRepository = new Mock<ICharacterRepository>();
        _mockAdapter = new Mock<ICharacterAdapter>();
        _mockValidations = new Mock<CharacterValidations>();

        _characterHandler = new CharacterHandler(
            _mockRepository.Object,
            _mockAdapter.Object
        );
    }

    [Fact]
    public async Task InsertAsync_CommandIsNull_ReturnsBadRequest()
    {
        // Act
        var result = await _characterHandler.InsertAsync(null);

        // Assert
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        Assert.Equal("Invalid parameters", result.Message);
    }

    [Fact]
    public async Task InsertAsync_CommandIsInvalid_ReturnsUnprocessableEntity()
    {
        // Arrange
        var invalidCommand = new CharacterAddCommand
        {
            Name = null,
            Race = null,
            Class = null,
            Nivel = 0,
            Background = null,
            ProficiencyBonus = 0,
            Strength = 0,
            Dexterity = 0,
            Constitution = 0,
            Intelligence = 0,
            Wisdom = 0,
            Charisma = 0
        };

        // Act
        var result = await _characterHandler.InsertAsync(invalidCommand);

        // Assert
        Assert.Equal(StatusCodes.Status422UnprocessableEntity, result.StatusCode);
        Assert.Equal("Invalid parameters", result.Message);
        Assert.Collection(result.Errors,
            e => Assert.Equal("Name", e.Property),
            e => Assert.Equal("Race", e.Property),
            e => Assert.Equal("Class", e.Property),
            e => Assert.Equal("Nivel", e.Property),
            e => Assert.Equal("Background", e.Property),
            e => Assert.Equal("ProficiencyBonus", e.Property),
            e => Assert.Equal("Strength", e.Property),
            e => Assert.Equal("Dexterity", e.Property),
            e => Assert.Equal("Constitution", e.Property),
            e => Assert.Equal("Intelligence", e.Property),
            e => Assert.Equal("Wisdom", e.Property),
            e => Assert.Equal("Charisma", e.Property)
        );
    }

    [Fact]
    public async Task InsertAsync_ValidCommand_CallsRepositoryAndAdapter_ReturnsCreated()
    {
        // Arrange
        var validCommand = new CharacterAddCommand
        {
            Name = "ValidName",
            Race = "ValidRace",
            Class = "ValidClass",
            Nivel = 1,
            Background = "ValidBackground",
            ProficiencyBonus = 1,
            Strength = 1,
            Dexterity = 1,
            Constitution = 1,
            Intelligence = 1,
            Wisdom = 1,
            Charisma = 1
        };

        // Act
        var result = await _characterHandler.InsertAsync(validCommand);

        // Assert
        Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        Assert.Equal("Character successfully inserted!", result.Message);
    }
}
