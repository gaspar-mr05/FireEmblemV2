

namespace Fire_Emblem.Models.Effects.EffectSummary;

public class StatEffectStatus
{
    public string Stat;
    public int Change;
    public bool Active;

    public StatEffectStatus(string stat)
    {
        Stat = stat;
        Change = 0;
        Active = false;
    }
}