using Fire_Emblem.Characters;

namespace Fire_Emblem.Models.Unit;

public class Characters
{
    private Dictionary<string, CharacterInfo> _characters = new();

    public void AddCharacter(CharacterInfo characterInfo) => _characters[characterInfo.Name] = characterInfo;

    public CharacterInfo GetCharacter(string characterName) => _characters[characterName];
}