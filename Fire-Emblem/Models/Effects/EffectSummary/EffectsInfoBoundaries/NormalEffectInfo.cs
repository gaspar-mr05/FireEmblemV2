namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class NormalEffectInfo
{
    private Dictionary<string, StatEffectStatus> _normalEffectInfo;
    
    public NormalEffectInfo()
    {
        
        _normalEffectInfo =  new Dictionary<string, StatEffectStatus>{
            { "Atk", new StatEffectStatus("Atk") },
            { "Spd", new StatEffectStatus("Spd") },
            { "Def", new StatEffectStatus("Def") },
            { "Res", new StatEffectStatus("Res") }
        };
        
    }

    public StatEffectStatus[] GetEffectStatuses()
    {
        StatEffectStatus[] statEffectSummaries = new StatEffectStatus[_normalEffectInfo.Count];
        int index = 0;
        foreach (KeyValuePair<string, StatEffectStatus> effect in _normalEffectInfo)
        {
            
            statEffectSummaries[index] = effect.Value;
            index += 1;

        }

        return statEffectSummaries;
    }

    public StatEffectStatus GetEffectInfo(string statName)
        => _normalEffectInfo[statName];

    public void SetActiveTrue(string statName)
        => _normalEffectInfo[statName].Active = true;

    public void SetActiveFalse(string statName)
        => _normalEffectInfo[statName].Active = false;

    public void SaveChange(string statName, int change) 
        => _normalEffectInfo[statName].Change += change;

    public int GetAllEffects()
    {
        int sum = 0;
        foreach (KeyValuePair<string, StatEffectStatus> effect in _normalEffectInfo)
        {
            sum += Math.Abs(effect.Value.Change);
        }

        return sum;
    }


    public bool IsContainingStatName(string statName) => _normalEffectInfo.ContainsKey(statName);
}