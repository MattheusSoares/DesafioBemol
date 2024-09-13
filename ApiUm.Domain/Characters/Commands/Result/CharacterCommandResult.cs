using Newtonsoft.Json;

namespace ApiUm.Domain.Characters.Commands.Result;

public class CharacterCommandResult
{
    [JsonProperty(PropertyName = "id")]
    public Guid Id { get; init; }

    [JsonProperty(PropertyName = "Name")]
    public string? Name { get; init; }

    [JsonProperty(PropertyName = "Race")]
    public string? Race { get; init; }

    [JsonProperty(PropertyName = "Class")]
    public string? Class { get; init; }

    [JsonProperty(PropertyName = "Nivel")]
    public int Nivel { get; init; }

    [JsonProperty(PropertyName = "Background")]
    public string? Background { get; init; }

    [JsonProperty(PropertyName = "ProficiencyBonus")]
    public int ProficiencyBonus { get; init; }

    [JsonProperty(PropertyName = "Strength")]
    public int Strength { get; init; }

    [JsonProperty(PropertyName = "Dexterity")]
    public int Dexterity { get; init; }

    [JsonProperty(PropertyName = "Constitution")]
    public int Constitution { get; init; }

    [JsonProperty(PropertyName = "Intelligence")]
    public int Intelligence { get; init; }

    [JsonProperty(PropertyName = "Wisdom")]
    public int Wisdom { get; init; }

    [JsonProperty(PropertyName = "Charisma")]
    public int Charisma { get; init; }

    public CharacterCommandResult() { }

    public CharacterCommandResult(Guid id, string? name, string? race, string? className, int nivel, string? background, int proficiencyBonus, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
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

    public CharacterCommandResult(string? name, string? race, string? className, int nivel, string? background, int proficiencyBonus, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
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
}
