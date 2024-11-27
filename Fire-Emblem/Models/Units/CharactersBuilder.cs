using System.Text.Json;

namespace Fire_Emblem.Models.Units;
using System.Text.Json.Serialization;
public class CharactersBuilder
{
    public static Characters CreateCharactersFromJson()
    {
        string characterJson = File . ReadAllText ( "characters.json") ;
        List<CharacterInfo> charactersList = JsonSerializer.Deserialize<List<CharacterInfo>>(characterJson);
        Characters characters = new Characters();
        foreach (var character in charactersList)
        {
            characters.AddCharacter(character);
        }
        return characters;
    }
}