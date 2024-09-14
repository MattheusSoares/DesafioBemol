using ApiUm.Domain.Characters.Validations;

namespace ApiUm.Domain.Test.Characters.Validations;

public class CharacterValidationsTests
{
    [Fact]
    public void ValidateId_ShouldNotAddNotification_WhenIdIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validId = Guid.NewGuid();

        // Act
        validations.ValidateId(validId);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateId_ShouldAddNotification_WhenIdIsEmpty()
    {
        // Arrange
        var validations = new CharacterValidations();
        var emptyId = Guid.Empty;

        // Act
        validations.ValidateId(emptyId);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateName_ShouldNotAddNotification_WhenNameIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validName = "Legolas";

        // Act
        validations.ValidateName(validName);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateName_ShouldAddNotification_WhenNameIsEmpty()
    {
        // Arrange
        var validations = new CharacterValidations();
        var emptyName = "";

        // Act
        validations.ValidateName(emptyName);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateName_ShouldAddNotification_WhenNameIsTooLong()
    {
        // Arrange
        var validations = new CharacterValidations();
        var longName = new string('a', 101);

        // Act
        validations.ValidateName(longName);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateRace_ShouldNotAddNotification_WhenRaceIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validRace = "Elf";

        // Act
        validations.ValidateRace(validRace);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateRace_ShouldAddNotification_WhenRaceIsEmpty()
    {
        // Arrange
        var validations = new CharacterValidations();
        var emptyRace = "";

        // Act
        validations.ValidateRace(emptyRace);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateRace_ShouldAddNotification_WhenRaceIsTooLong()
    {
        // Arrange
        var validations = new CharacterValidations();
        var longRace = new string('a', 101);

        // Act
        validations.ValidateRace(longRace);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateClass_ShouldNotAddNotification_WhenClassIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validClass = "Ranger";

        // Act
        validations.ValidateClass(validClass);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateClass_ShouldAddNotification_WhenClassIsEmpty()
    {
        // Arrange
        var validations = new CharacterValidations();
        var emptyClass = "";

        // Act
        validations.ValidateClass(emptyClass);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateClass_ShouldAddNotification_WhenClassIsTooLong()
    {
        // Arrange
        var validations = new CharacterValidations();
        var longClass = new string('a', 101);

        // Act
        validations.ValidateClass(longClass);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateNivel_ShouldNotAddNotification_WhenNivelIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validNivel = 10;

        // Act
        validations.ValidateNivel(validNivel);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateNivel_ShouldAddNotification_WhenNivelIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidNivel = 0;

        // Act
        validations.ValidateNivel(invalidNivel);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateNivel_ShouldAddNotification_WhenNivelIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidNivel = 21;

        // Act
        validations.ValidateNivel(invalidNivel);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateBackground_ShouldNotAddNotification_WhenBackgroundIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validBackground = "Noble";

        // Act
        validations.ValidateBackground(validBackground);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateBackground_ShouldAddNotification_WhenBackgroundIsEmpty()
    {
        // Arrange
        var validations = new CharacterValidations();
        var emptyBackground = "";

        // Act
        validations.ValidateBackground(emptyBackground);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateBackground_ShouldAddNotification_WhenBackgroundIsTooLong()
    {
        // Arrange
        var validations = new CharacterValidations();
        var longBackground = new string('a', 101);

        // Act
        validations.ValidateBackground(longBackground);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateProficiencyBonus_ShouldNotAddNotification_WhenProficiencyBonusIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validBonus = 4;

        // Act
        validations.ValidateProficiencyBonus(validBonus);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateProficiencyBonus_ShouldAddNotification_WhenProficiencyBonusIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidBonus = 0;

        // Act
        validations.ValidateProficiencyBonus(invalidBonus);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateProficiencyBonus_ShouldAddNotification_WhenProficiencyBonusIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidBonus = 7;

        // Act
        validations.ValidateProficiencyBonus(invalidBonus);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateStrength_ShouldNotAddNotification_WhenStrengthIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validStrength = 15;

        // Act
        validations.ValidateStrength(validStrength);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateStrength_ShouldAddNotification_WhenStrengthIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidStrength = 0;

        // Act
        validations.ValidateStrength(invalidStrength);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateStrength_ShouldAddNotification_WhenStrengthIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidStrength = 31;

        // Act
        validations.ValidateStrength(invalidStrength);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateDexterity_ShouldNotAddNotification_WhenDexterityIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validDexterity = 14;

        // Act
        validations.ValidateDexterity(validDexterity);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateDexterity_ShouldAddNotification_WhenDexterityIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidDexterity = 0;

        // Act
        validations.ValidateDexterity(invalidDexterity);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateDexterity_ShouldAddNotification_WhenDexterityIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidDexterity = 31;

        // Act
        validations.ValidateDexterity(invalidDexterity);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateConstitution_ShouldNotAddNotification_WhenConstitutionIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validConstitution = 13;

        // Act
        validations.ValidateConstitution(validConstitution);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateConstitution_ShouldAddNotification_WhenConstitutionIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidConstitution = 0;

        // Act
        validations.ValidateConstitution(invalidConstitution);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateConstitution_ShouldAddNotification_WhenConstitutionIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidConstitution = 31;

        // Act
        validations.ValidateConstitution(invalidConstitution);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateIntelligence_ShouldNotAddNotification_WhenIntelligenceIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validIntelligence = 12;

        // Act
        validations.ValidateIntelligence(validIntelligence);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateIntelligence_ShouldAddNotification_WhenIntelligenceIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidIntelligence = 0;

        // Act
        validations.ValidateIntelligence(invalidIntelligence);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateIntelligence_ShouldAddNotification_WhenIntelligenceIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidIntelligence = 31;

        // Act
        validations.ValidateIntelligence(invalidIntelligence);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateWisdom_ShouldNotAddNotification_WhenWisdomIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validWisdom = 16;

        // Act
        validations.ValidateWisdom(validWisdom);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateWisdom_ShouldAddNotification_WhenWisdomIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidWisdom = 0;

        // Act
        validations.ValidateWisdom(invalidWisdom);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateWisdom_ShouldAddNotification_WhenWisdomIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidWisdom = 31;

        // Act
        validations.ValidateWisdom(invalidWisdom);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateCharisma_ShouldNotAddNotification_WhenCharismaIsValid()
    {
        // Arrange
        var validations = new CharacterValidations();
        var validCharisma = 18;

        // Act
        validations.ValidateCharisma(validCharisma);

        // Assert
        Assert.Empty(validations.Notifications);
    }

    [Fact]
    public void ValidateCharisma_ShouldAddNotification_WhenCharismaIsTooLow()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidCharisma = 0;

        // Act
        validations.ValidateCharisma(invalidCharisma);

        // Assert
        Assert.Single(validations.Notifications);
    }

    [Fact]
    public void ValidateCharisma_ShouldAddNotification_WhenCharismaIsTooHigh()
    {
        // Arrange
        var validations = new CharacterValidations();
        var invalidCharisma = 31;

        // Act
        validations.ValidateCharisma(invalidCharisma);

        // Assert
        Assert.Single(validations.Notifications);
    }
}