using System.Reflection;

namespace Fire_Emblem.Characters;

public class CharacterInfo
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public string HP { get; set; }
    public string Atk { get; set; }
    public string Spd { get; set; }
    public string Def { get; set; }
    public string Res { get; set; }
    
    public string? GetInfoByName(string statName)
    {
        PropertyInfo? property = this.GetType().GetProperty(statName, BindingFlags.Public | BindingFlags.Instance);
        
        return property?.GetValue(this)?.ToString();
    }
}