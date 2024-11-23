namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class NeutralizationEffectInfo
{
    private Dictionary<string, bool> _neutralizationEffectInfo;

    public NeutralizationEffectInfo()
    {
        _neutralizationEffectInfo = new Dictionary<string, bool>
        {
            { "Atk", false },
            { "Spd", false },
            { "Def", false },
            { "Res", false }
        };
    }
    public (string statName, bool active)[] GetNeutralizationEffectSummaries()
    {
        (string statName, bool active)[] neutralizationEffectSummaries = new (string, bool)[_neutralizationEffectInfo.Count];
        
        int index = 0;
        foreach (KeyValuePair<string, bool> entry in _neutralizationEffectInfo)
        {
            neutralizationEffectSummaries[index] = (entry.Key, entry.Value);
            index += 1;
        }
    
        return neutralizationEffectSummaries;
    }

    
    public void SetActiveTrue(string statName)
        => _neutralizationEffectInfo[statName] = true;
    
}