using Fire_Emblem.Models.Enums;

namespace Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;

public class PercentageDamageEffectInfo
{
    private Dictionary<EffectDuration, PercentageEffectStatus> _percentageDamageEffectInfo;

    public PercentageDamageEffectInfo()
    {
        _percentageDamageEffectInfo = new Dictionary<EffectDuration, PercentageEffectStatus>
        {
            { EffectDuration.FullRound, new PercentageEffectStatus() },
            { EffectDuration.FirstAttack, new PercentageEffectStatus() },
            { EffectDuration.FollowUp, new PercentageEffectStatus() } 
        };
    }

    public PercentageEffectStatus GetPercentageReduction(EffectDuration effectDuration)
        => _percentageDamageEffectInfo[effectDuration];
    
}