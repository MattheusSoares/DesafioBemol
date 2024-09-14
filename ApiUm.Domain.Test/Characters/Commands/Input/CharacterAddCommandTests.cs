using ApiUm.Domain.Characters.Commands.Input;

namespace ApiUm.Domain.Test.Characters.Commands.Input;

public class CharacterAddCommandTests
{
    [Fact]
    public void IsValid_ShouldReturnTrueWhenAllPropertiesAreValid()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
            Name = "Aragorn",
            Race = "Human",
            Class = "Ranger",
            Nivel = 5,
            Background = "Noble",
            ProficiencyBonus = 2,
            Strength = 18,
            Dexterity = 16,
            Constitution = 14,
            Intelligence = 12,
            Wisdom = 15,
            Charisma = 10
        };

        // Act
        var result = command.IsValid();

        // Assert
        Assert.True(result);
        Assert.Empty(command.Notifications);
    }

    [Fact]
    public void IsValid_ShouldReturnFalseWhenSomePropertiesAreInvalid()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
            Name = "",
            Race = null,
            Class = "Ranger",
            Nivel = 0,
            Background = "A background that is way too long and exceeds the character limit of 100 characters which should cause an error",
            ProficiencyBonus = 7,
            Strength = 50,
            Dexterity = 5,
            Constitution = 14,
            Intelligence = 12,
            Wisdom = 15,
            Charisma = 10
        };

        // Act
        var result = command.IsValid();

        // Assert
        Assert.False(result);
        Assert.NotEmpty(command.Notifications);
    }

    [Fact]
    public void MapToCharacter_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
            Name = "Legolas",
            Race = "Elf",
            Class = "Archer",
            Nivel = 10,
            Background = "Warrior",
            ProficiencyBonus = 4,
            Strength = 15,
            Dexterity = 20,
            Constitution = 13,
            Intelligence = 14,
            Wisdom = 18,
            Charisma = 12
        };

        // Act
        var character = command.MapToCharacter();

        // Assert
        Assert.Equal(command.Name, character.Name);
        Assert.Equal(command.Race, character.Race);
        Assert.Equal(command.Class, character.Class);
        Assert.Equal(command.Nivel, character.Nivel);
        Assert.Equal(command.Background, character.Background);
        Assert.Equal(command.ProficiencyBonus, character.ProficiencyBonus);
        Assert.Equal(command.Strength, character.Strength);
        Assert.Equal(command.Dexterity, character.Dexterity);
        Assert.Equal(command.Constitution, character.Constitution);
        Assert.Equal(command.Intelligence, character.Intelligence);
        Assert.Equal(command.Wisdom, character.Wisdom);
        Assert.Equal(command.Charisma, character.Charisma);
    }

    [Fact]
    public void IsValid_ShouldReturnTrueForEdgeValidNumericProperties()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
            Name = "Gandalf",
            Race = "Maiar",
            Class = "Wizard",
            Nivel = 20,
            Background = "Istari",
            ProficiencyBonus = 6,
            Strength = 30,
            Dexterity = 30,
            Constitution = 30,
            Intelligence = 30,
            Wisdom = 30,
            Charisma = 30
        };

        // Act
        var result = command.IsValid();

        // Assert
        Assert.True(result);
        Assert.Empty(command.Notifications);
    }

    [Fact]
    public void IsValid_ShouldReturnFalseForEdgeInvalidNumericProperties()
    {
        // Arrange
        var command = new CharacterAddCommand
        {
            Name = "Saruman",
            Race = "Maiar",
            Class = "Wizard",
            Nivel = 21,
            Background = "Istari",
            ProficiencyBonus = 0,
            Strength = 0,
            Dexterity = 31,
            Constitution = 31,
            Intelligence = 31,
            Wisdom = 31,
            Charisma = 31
        };

        // Act
        var result = command.IsValid();

        // Assert
        Assert.False(result);
        Assert.NotEmpty(command.Notifications);
    }
}
