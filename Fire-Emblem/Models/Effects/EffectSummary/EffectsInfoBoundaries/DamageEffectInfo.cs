using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class DamageEffectInfo
{
    private Dictionary<EffectDuration, DamageEffectStatus> _damageEffectInfo;

    public DamageEffectInfo()
    {
        _damageEffectInfo =  new Dictionary<EffectDuration, DamageEffectStatus>
        {
            { EffectDuration.FullRound, new DamageEffectStatus()},
            { EffectDuration.FirstAttack, new DamageEffectStatus()},
            { EffectDuration.FollowUp, new DamageEffectStatus()},
            { EffectDuration.BeforeCombat, new DamageEffectStatus()},
            { EffectDuration.AfterCombat, new DamageEffectStatus()}
        };
    }

    public DamageEffectStatus GetDamageInfo(EffectDuration effectDuration)
        => _damageEffectInfo[effectDuration];
    


}