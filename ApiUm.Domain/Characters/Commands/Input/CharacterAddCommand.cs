using ApiUm.Domain.Characters.Entities;
using ApiUm.Domain.Characters.Validations;
using ApiUm.Domain.Shared.Commands.Interfaces;
using ApiUm.Domain.Shared.Notifications;

namespace ApiUm.Domain.Characters.Commands.Input;

public class CharacterAddCommand : Notifier, IStandardCommand
{
    public string? Name { get; init; }
    public string? Race { get; init; }
    public string? Class { get; init; }
    public int Nivel { get; init; }
    public string? Background { get; init; }
    public int ProficiencyBonus { get; init; }
    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }

    public bool IsValid()
    {
        AddNotification(new CharacterValidations().ValidateCommand(this));
        return Valid;
    }

    public Character MapToCharacter() => new Character(Name, Race, Class, Nivel, Background, ProficiencyBonus, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
}
