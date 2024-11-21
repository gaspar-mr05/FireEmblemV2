using System.Text.Json;

namespace Fire_Emblem.Characters;
using System.Text.Json.Serialization;
public class CharactersBuilder
{
    public static Models.Unit.Characters CreateCharactersFromJson()
    {
        string characterJson = File . ReadAllText ( "characters.json") ;
        List<CharacterInfo> charactersList = JsonSerializer.Deserialize<List<CharacterInfo>>(characterJson);
        Models.Unit.Characters characters = new Models.Unit.Characters();
        foreach (var character in charactersList)
        {
            characters.AddCharacter(character);
        }
        return characters;
    }
}