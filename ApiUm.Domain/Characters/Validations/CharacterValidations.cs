using ApiUm.Domain.Characters.Commands.Input;
using ApiUm.Domain.Shared.Notifications;

namespace ApiUm.Domain.Characters.Validations;

public class CharacterValidations : Notifier
{
    public IReadOnlyCollection<Notification> ValidateId(Guid id)
    {
        if (id == Guid.Empty)
            AddNotification("Id", $"Id must be a valid GUID");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            AddNotification("Name", "Name is a required field");
        else if (name.Length > 100)
            AddNotification("Name", $"Name must contain a maximum of 100 characters");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateRace(string? race)
    {
        if (string.IsNullOrWhiteSpace(race))
            AddNotification("Race", "Race is a required field");
        else if (race.Length > 100)
            AddNotification("Race", $"Race must contain a maximum of 100 characters");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateClass(string? className)
    {
        if (string.IsNullOrWhiteSpace(className))
            AddNotification("Class", "Class is a required field");
        else if (className.Length > 100)
            AddNotification("Class", $"Class must contain a maximum of 100 characters");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateNivel(int nivel)
    {
        if (nivel < 1 || nivel > 20)
            AddNotification("Nivel", $"Nivel must be between 1 and 20");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateBackground(string? background)
    {
        if (string.IsNullOrWhiteSpace(background))
            AddNotification("Background", "Background is a required field");
        else if (background.Length > 100)
            AddNotification("Background", $"Background must contain a maximum of 100 characters");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateProficiencyBonus(int proficiencyBonus)
    {
        if (proficiencyBonus < 1 || proficiencyBonus > 6)
            AddNotification("ProficiencyBonus", $"ProficiencyBonus must be between 1 and 6");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateStrength(int strength)
    {
        if (strength < 1 || strength > 30)
            AddNotification("Strength", $"Strength must be between 1 and 30");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateDexterity(int dexterity)
    {
        if (dexterity < 1 || dexterity > 30)
            AddNotification("Dexterity", $"Dexterity must be between 1 and 30");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateConstitution(int constitution)
    {
        if (constitution < 1 || constitution > 30)
            AddNotification("Constitution", $"Constitution must be between 1 and 30");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateIntelligence(int intelligence)
    {
        if (intelligence < 1 || intelligence > 30)
            AddNotification("Intelligence", $"Intelligence must be between 1 and 30");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateWisdom(int wisdom)
    {
        if (wisdom < 1 || wisdom > 30)
            AddNotification("Wisdom", $"Wisdom must be between 1 and 30");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateCharisma(int charisma)
    {
        if (charisma < 1 || charisma > 30)
            AddNotification("Charisma", $"Charisma must be between 1 and 30");

        return Notifications;
    }

    public IReadOnlyCollection<Notification> ValidateCommand(CharacterAddCommand command)
    {
        ValidateName(command.Name);
        ValidateRace(command.Race);
        ValidateClass(command.Class);
        ValidateNivel(command.Nivel);
        ValidateBackground(command.Background);
        ValidateProficiencyBonus(command.ProficiencyBonus);
        ValidateStrength(command.Strength);
        ValidateDexterity(command.Dexterity);
        ValidateConstitution(command.Constitution);
        ValidateIntelligence(command.Intelligence);
        ValidateWisdom(command.Wisdom);
        ValidateCharisma(command.Charisma);
        return Notifications;
    }
}

