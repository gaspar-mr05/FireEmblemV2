using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects.DamageEffects;

public class ExtraDamageEffect: DamageEffect
{
    private int _change;

    public ExtraDamageEffect(Unit unit, int change, EffectDuration effectDuration)
    {
        base.Unit = unit;
        base.EffectDuration = effectDuration;
        _change = change;

    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectInfo extraDamageEffectsInfo = effectsSummary.ExtraDamageEffectInfo;
        DamageEffectStatus extraDamageInfo = extraDamageEffectsInfo.GetDamageInfo(EffectDuration);
        extraDamageInfo.Active = true;  
        extraDamageInfo.Change += _change;
        extraDamageEffectsInfo.SetDamageInfo(EffectDuration, extraDamageInfo); 
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}