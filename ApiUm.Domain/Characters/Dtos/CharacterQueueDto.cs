using ApiUm.Domain.Characters.Entities;

namespace ApiUm.Domain.Characters.Dtos;

public class CharacterQueueDto
{
    public Guid Id { get; init; }
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

    public CharacterQueueDto(Character character)
    {
        Id = character.Id;
        Name = character.Name;
        Race = character.Race;
        Class = character.Class;
        Nivel = character.Nivel;
        Background = character.Background;
        ProficiencyBonus = character.ProficiencyBonus;
        Strength = character.Strength;
        Dexterity = character.Dexterity;
        Constitution = character.Constitution;
        Intelligence = character.Intelligence;
        Wisdom = character.Wisdom;
        Charisma = character.Charisma;
    }
}
