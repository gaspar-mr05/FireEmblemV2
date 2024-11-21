using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects.DamageEffects;

public class AbsoluteDamageReduction : DamageEffect
{
    private int _change;
    

    public AbsoluteDamageReduction(Unit unit, int change, EffectDuration effectDuration)
    {
        base.Unit = unit;
        base.EffectDuration = effectDuration;
        _change = change;
    }
        
        
    public override void ApplyEffect()
    {
        
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectInfo absoluteDamageReductionEffectInfo = effectsSummary.AbsoluteDamageReductionEffectInfo;
        DamageEffectStatus absoluteReductionInfo = absoluteDamageReductionEffectInfo.GetDamageInfo(EffectDuration);
        absoluteReductionInfo.Active = true;  
        absoluteReductionInfo.Change -= _change;
        absoluteDamageReductionEffectInfo.SetDamageInfo(EffectDuration, absoluteReductionInfo); 
        
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}