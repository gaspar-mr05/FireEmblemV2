using System.Reflection;

namespace Fire_Emblem.Characters;

public class CharacterInfo(string name, string weapon, string gender, string deathQuote, string hp, string atk, 
    string spd, string def, string res)
{
    public string Name { get; set; } = name;
    public string Weapon { get; set; } = weapon;
    public string Gender { get; set; } = gender;
    public string DeathQuote { get; set; } = deathQuote;
    public string HP { get; set; } = hp;
    public string Atk { get; set; } = atk;
    public string Spd { get; set; } = spd;
    public string Def { get; set; } = def;
    public string Res { get; set; } = res;
    
    
    public string? GetInfoByName(string statName)
    {
        PropertyInfo? property = this.GetType().GetProperty(statName, BindingFlags.Public | BindingFlags.Instance);
        
        return property?.GetValue(this)?.ToString();
    }
}