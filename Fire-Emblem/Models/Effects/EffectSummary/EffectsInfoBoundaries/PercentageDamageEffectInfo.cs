using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class PercentageDamageEffectInfo
{
    private Dictionary<EffectDuration, PercentageDamageEffectStatus> _percentageDamageEffectInfo;

    public PercentageDamageEffectInfo()
    {
        _percentageDamageEffectInfo = new Dictionary<EffectDuration, PercentageDamageEffectStatus>
        {
            { EffectDuration.FullRound, new PercentageDamageEffectStatus() },
            { EffectDuration.FirstAttack, new PercentageDamageEffectStatus() },
            { EffectDuration.FollowUp, new PercentageDamageEffectStatus() } 
        };
    }

    public PercentageDamageEffectStatus GetPercentageReduction(EffectDuration effectDuration)
        => _percentageDamageEffectInfo[effectDuration];
    
    public void SetPercentageReduction(EffectDuration effectDuration, PercentageDamageEffectStatus percentageReduction)
        => _percentageDamageEffectInfo[effectDuration] = percentageReduction;
}