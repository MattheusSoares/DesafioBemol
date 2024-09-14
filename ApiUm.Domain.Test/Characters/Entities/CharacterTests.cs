using ApiUm.Domain.Characters.Entities;

namespace ApiUm.Domain.Test.Characters.Entities;

public class CharacterTests
{
    [Fact]
    public void Constructor_Default_ShouldInitializeWithDefaultValues()
    {
        // Arrange & Act
        var character = new Character();

        // Assert
        Assert.Equal(Guid.Empty, character.Id);
        Assert.Equal("PartitionKey", character.PartitionKey);
        Assert.Null(character.Name);
        Assert.Null(character.Race);
        Assert.Null(character.Class);
        Assert.Equal(0, character.Nivel);
        Assert.Null(character.Background);
        Assert.Equal(0, character.ProficiencyBonus);
        Assert.Equal(0, character.Strength);
        Assert.Equal(0, character.Dexterity);
        Assert.Equal(0, character.Constitution);
        Assert.Equal(0, character.Intelligence);
        Assert.Equal(0, character.Wisdom);
        Assert.Equal(0, character.Charisma);
    }

    [Fact]
    public void Constructor_WithParameters_ShouldInitializeCorrectly()
    {
        // Arrange
        var name = "Hero";
        var race = "Elf";
        var className = "Warrior";
        var nivel = 10;
        var background = "Noble";
        var proficiencyBonus = 2;
        var strength = 18;
        var dexterity = 15;
        var constitution = 14;
        var intelligence = 12;
        var wisdom = 10;
        var charisma = 8;

        // Act
        var character = new Character(name, race, className, nivel, background, proficiencyBonus, strength, dexterity, constitution, intelligence, wisdom, charisma);

        // Assert
        Assert.NotEqual(Guid.Empty, character.Id);
        Assert.Equal(name, character.Name);
        Assert.Equal(race, character.Race);
        Assert.Equal(className, character.Class);
        Assert.Equal(nivel, character.Nivel);
        Assert.Equal(background, character.Background);
        Assert.Equal(proficiencyBonus, character.ProficiencyBonus);
        Assert.Equal(strength, character.Strength);
        Assert.Equal(dexterity, character.Dexterity);
        Assert.Equal(constitution, character.Constitution);
        Assert.Equal(intelligence, character.Intelligence);
        Assert.Equal(wisdom, character.Wisdom);
        Assert.Equal(charisma, character.Charisma);
    }

    [Fact]
    public void MapToCharacterCommandResult_ShouldReturnCorrectValues()
    {
        // Arrange
        var character = new Character("Hero", "Elf", "Warrior", 10, "Noble", 2, 18, 15, 14, 12, 10, 8);

        // Act
        var result = character.MapToCharacterCommandResult();

        // Assert
        Assert.Equal(character.Id, result.Id);
        Assert.Equal(character.Name, result.Name);
        Assert.Equal(character.Race, result.Race);
        Assert.Equal(character.Class, result.Class);
        Assert.Equal(character.Nivel, result.Nivel);
        Assert.Equal(character.Background, result.Background);
        Assert.Equal(character.ProficiencyBonus, result.ProficiencyBonus);
        Assert.Equal(character.Strength, result.Strength);
        Assert.Equal(character.Dexterity, result.Dexterity);
        Assert.Equal(character.Constitution, result.Constitution);
        Assert.Equal(character.Intelligence, result.Intelligence);
        Assert.Equal(character.Wisdom, result.Wisdom);
        Assert.Equal(character.Charisma, result.Charisma);
    }

    [Fact]
    public void SetId_ShouldSetIdAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var id = Guid.NewGuid();

        // Act
        character.SetId(id);

        // Assert
        Assert.Equal(id, character.Id);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetId_ShouldTriggerValidationErrorForEmptyGuid()
    {
        // Arrange
        var character = new Character();
        var id = Guid.Empty;

        // Act
        character.SetId(id);

        // Assert
        Assert.Equal(id, character.Id);
        Assert.Single(character.Notifications);
        Assert.Equal("Id", character.Notifications.First().Property);
    }

    [Fact]
    public void SetName_ShouldSetNameAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var name = "Hero";

        // Act
        character.SetName(name);

        // Assert
        Assert.Equal(name, character.Name);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetName_ShouldTriggerValidationErrorForEmptyName()
    {
        // Arrange
        var character = new Character();
        string? name = "";

        // Act
        character.SetName(name);

        // Assert
        Assert.Equal(name, character.Name);
        Assert.Single(character.Notifications);
        Assert.Equal("Name", character.Notifications.First().Property);
    }

    [Fact]
    public void SetRace_ShouldSetRaceAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var race = "Elf";

        // Act
        character.SetRace(race);

        // Assert
        Assert.Equal(race, character.Race);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetRace_ShouldTriggerValidationErrorForEmptyRace()
    {
        // Arrange
        var character = new Character();
        string? race = "";

        // Act
        character.SetRace(race);

        // Assert
        Assert.Equal(race, character.Race);
        Assert.Single(character.Notifications);
        Assert.Equal("Race", character.Notifications.First().Property);
    }

    [Fact]
    public void SetClass_ShouldSetClassAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var className = "Warrior";

        // Act
        character.SetClass(className);

        // Assert
        Assert.Equal(className, character.Class);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetClass_ShouldTriggerValidationErrorForEmptyClass()
    {
        // Arrange
        var character = new Character();
        string? className = "";

        // Act
        character.SetClass(className);

        // Assert
        Assert.Equal(className, character.Class);
        Assert.Single(character.Notifications);
        Assert.Equal("Class", character.Notifications.First().Property);
    }

    [Fact]
    public void SetNivel_ShouldSetNivelAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var nivel = 10;

        // Act
        character.SetNivel(nivel);

        // Assert
        Assert.Equal(nivel, character.Nivel);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetNivel_ShouldTriggerValidationErrorForInvalidLevel()
    {
        // Arrange
        var character = new Character();
        var nivel = 0;

        // Act
        character.SetNivel(nivel);

        // Assert
        Assert.Equal(nivel, character.Nivel);
        Assert.Single(character.Notifications);
        Assert.Equal("Nivel", character.Notifications.First().Property);
    }

    [Fact]
    public void SetProficiencyBonus_ShouldSetProficiencyBonusAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var proficiencyBonus = 3;

        // Act
        character.SetProficiencyBonus(proficiencyBonus);

        // Assert
        Assert.Equal(proficiencyBonus, character.ProficiencyBonus);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetProficiencyBonus_ShouldTriggerValidationErrorForInvalidProficiencyBonus()
    {
        // Arrange
        var character = new Character();
        var proficiencyBonus = 7;

        // Act
        character.SetProficiencyBonus(proficiencyBonus);

        // Assert
        Assert.Equal(proficiencyBonus, character.ProficiencyBonus);
        Assert.Single(character.Notifications);
        Assert.Equal("ProficiencyBonus", character.Notifications.First().Property);
    }

    [Fact]
    public void SetStrength_ShouldSetStrengthAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var strength = 20;

        // Act
        character.SetStrength(strength);

        // Assert
        Assert.Equal(strength, character.Strength);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetStrength_ShouldTriggerValidationErrorForInvalidStrength()
    {
        // Arrange
        var character = new Character();
        var strength = 31;

        // Act
        character.SetStrength(strength);

        // Assert
        Assert.Equal(strength, character.Strength);
        Assert.Single(character.Notifications);
        Assert.Equal("Strength", character.Notifications.First().Property);
    }

    [Fact]
    public void SetDexterity_ShouldSetDexterityAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var dexterity = 18;

        // Act
        character.SetDexterity(dexterity);

        // Assert
        Assert.Equal(dexterity, character.Dexterity);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetDexterity_ShouldTriggerValidationErrorForInvalidDexterity()
    {
        // Arrange
        var character = new Character();
        var dexterity = 35;

        // Act
        character.SetDexterity(dexterity);

        // Assert
        Assert.Equal(dexterity, character.Dexterity);
        Assert.Single(character.Notifications);
        Assert.Equal("Dexterity", character.Notifications.First().Property);
    }

    [Fact]
    public void SetConstitution_ShouldSetConstitutionAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var constitution = 16;

        // Act
        character.SetConstitution(constitution);

        // Assert
        Assert.Equal(constitution, character.Constitution);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetConstitution_ShouldTriggerValidationErrorForInvalidConstitution()
    {
        // Arrange
        var character = new Character();
        var constitution = 31;

        // Act
        character.SetConstitution(constitution);

        // Assert
        Assert.Equal(constitution, character.Constitution);
        Assert.Single(character.Notifications);
        Assert.Equal("Constitution", character.Notifications.First().Property);
    }

    [Fact]
    public void SetIntelligence_ShouldSetIntelligenceAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var intelligence = 14;

        // Act
        character.SetIntelligence(intelligence);

        // Assert
        Assert.Equal(intelligence, character.Intelligence);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetIntelligence_ShouldTriggerValidationErrorForInvalidIntelligence()
    {
        // Arrange
        var character = new Character();
        var intelligence = 32;

        // Act
        character.SetIntelligence(intelligence);

        // Assert
        Assert.Equal(intelligence, character.Intelligence);
        Assert.Single(character.Notifications);
        Assert.Equal("Intelligence", character.Notifications.First().Property);
    }

    [Fact]
    public void SetWisdom_ShouldSetWisdomAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var wisdom = 12;

        // Act
        character.SetWisdom(wisdom);

        // Assert
        Assert.Equal(wisdom, character.Wisdom);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetWisdom_ShouldTriggerValidationErrorForInvalidWisdom()
    {
        // Arrange
        var character = new Character();
        var wisdom = 0;

        // Act
        character.SetWisdom(wisdom);

        // Assert
        Assert.Equal(wisdom, character.Wisdom);
        Assert.Single(character.Notifications);
        Assert.Equal("Wisdom", character.Notifications.First().Property);
    }

    [Fact]
    public void SetCharisma_ShouldSetCharismaAndNotTriggerValidationError()
    {
        // Arrange
        var character = new Character();
        var charisma = 15;

        // Act
        character.SetCharisma(charisma);

        // Assert
        Assert.Equal(charisma, character.Charisma);
        Assert.Empty(character.Notifications);
    }

    [Fact]
    public void SetCharisma_ShouldTriggerValidationErrorForInvalidCharisma()
    {
        // Arrange
        var character = new Character();
        var charisma = 50;

        // Act
        character.SetCharisma(charisma);

        // Assert
        Assert.Equal(charisma, character.Charisma);
        Assert.Single(character.Notifications);
        Assert.Equal("Charisma", character.Notifications.First().Property);
    }
}
