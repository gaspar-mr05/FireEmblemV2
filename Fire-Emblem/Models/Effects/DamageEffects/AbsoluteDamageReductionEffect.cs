using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.DamageEffects;

public class AbsoluteDamageReductionEffect : DamageEffect
{
    private int _change;
    

    public AbsoluteDamageReductionEffect(Unit unit, int change, EffectDuration effectDuration): base(unit, effectDuration)
    {
        _change = change;
    }
        
        
    public override void ApplyEffect()
    {
        
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectInfo absoluteDamageReductionEffectInfo = effectsSummary.AbsoluteDamageReductionInfo;
        DamageEffectStatus absoluteReductionInfo = absoluteDamageReductionEffectInfo.GetDamageInfo(EffectDuration);
        absoluteReductionInfo.Active = true;  
        absoluteReductionInfo.Damage -= _change;
        
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }

    public override int GetPriority() => 5;
}