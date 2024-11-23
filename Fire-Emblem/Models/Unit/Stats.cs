using Fire_Emblem.Characters;

namespace Fire_Emblem.Models.Unit;

public class Stats
{
    private Dictionary<string, int> _stats;

    public Stats(CharacterInfo characterInfo)
    {
        _stats = new Dictionary<string, int>
        {
            { "HP", Convert.ToInt32(characterInfo.HP) },
            { "Atk", Convert.ToInt32(characterInfo.Atk) },
            { "Spd", Convert.ToInt32(characterInfo.Spd) },
            { "Def", Convert.ToInt32(characterInfo.Def) },
            { "Res", Convert.ToInt32(characterInfo.Res) }
        };

    }
    
    private Stats()
    {
        _stats = new Dictionary<string, int>();
    }

    public int GetHp() => _stats["HP"];
    
    public int GetAtk() => _stats["Atk"];
    
    public int GetSpd() => _stats["Spd"];
    
    public int GetDef() => _stats["Def"];
    
    public int GetRes() => _stats["Res"];

    public int GetStat(string statName) => _stats[statName];

    public void AddChange(string statName, int change) => _stats[statName] += change;
    
    public void SetStat(string statName, int change) => _stats[statName] = change;

    public Stats Clone()
    {
        Stats clonedStats = new Stats();
        foreach (var stat in _stats)
        {
            clonedStats._stats[stat.Key] = stat.Value;
        }
        return clonedStats;
    }

}