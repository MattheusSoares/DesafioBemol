using ApiUm.Domain.Characters.Commands.Result;
using ApiUm.Domain.Characters.Validations;
using ApiUm.Domain.Shared.Notifications;
using Newtonsoft.Json;

namespace ApiUm.Domain.Characters.Entities;

public class Character : Notifier
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; private set; }
    [JsonProperty(PropertyName = "CharacterPartitionKey")]
    public string PartitionKey { get; set; } = "PartitionKey";
    public string? Name { get; private set; }
    public string? Race { get; private set; }
    public string? Class { get; private set; }
    public int Nivel { get; private set; }
    public string? Background { get; private set; }
    public int ProficiencyBonus { get; private set; }
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }

    public Character() { }

    public Character(string? name, string? race, string? className, int nivel, string? background, int proficiencyBonus, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Id = Guid.NewGuid();
        Name = name;
        Race = race;
        Class = className;
        Nivel = nivel;
        Background = background;
        ProficiencyBonus = proficiencyBonus;
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }

    public Character(Guid id, string? name, string? race, string? className, int nivel, string? background, int proficiencyBonus, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Id = id;
        Name = name;
        Race = race;
        Class = className;
        Nivel = nivel;
        Background = background;
        ProficiencyBonus = proficiencyBonus;
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }

    public void SetId(Guid id)
    {
        Id = id;
        AddNotification(new CharacterValidations().ValidateId(Id));
    }

    public void SetName(string? name)
    {
        Name = name;
        AddNotification(new CharacterValidations().ValidateName(Name));
    }

    public void SetRace(string? race)
    {
        Race = race;
        AddNotification(new CharacterValidations().ValidateRace(Race));
    }

    public void SetClass(string? className)
    {
        Class = className;
        AddNotification(new CharacterValidations().ValidateClass(Class));
    }

    public void SetNivel(int nivel)
    {
        Nivel = nivel;
        AddNotification(new CharacterValidations().ValidateNivel(Nivel));
    }

    public void SetBackground(string? background)
    {
        Background = background;
        AddNotification(new CharacterValidations().ValidateBackground(Background));
    }

    public void SetProficiencyBonus(int proficiencyBonus)
    {
        ProficiencyBonus = proficiencyBonus;
        AddNotification(new CharacterValidations().ValidateProficiencyBonus(ProficiencyBonus));
    }

    public void SetStrength(int strength)
    {
        Strength = strength;
        AddNotification(new CharacterValidations().ValidateStrength(Strength));
    }

    public void SetDexterity(int dexterity)
    {
        Dexterity = dexterity;
        AddNotification(new CharacterValidations().ValidateDexterity(Dexterity));
    }

    public void SetConstitution(int constitution)
    {
        Constitution = constitution;
        AddNotification(new CharacterValidations().ValidateConstitution(Constitution));
    }

    public void SetIntelligence(int intelligence)
    {
        Intelligence = intelligence;
        AddNotification(new CharacterValidations().ValidateIntelligence(Intelligence));
    }

    public void SetWisdom(int wisdom)
    {
        Wisdom = wisdom;
        AddNotification(new CharacterValidations().ValidateWisdom(Wisdom));
    }

    public void SetCharisma(int charisma)
    {
        Charisma = charisma;
        AddNotification(new CharacterValidations().ValidateCharisma(Charisma));
    }

    public CharacterCommandResult MapToCharacterCommandResult() => new(Id, Name, Race, Class, Nivel, Background, ProficiencyBonus, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
}

