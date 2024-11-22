using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects.DamageEffects;

public class ExtraDamageEffect: DamageEffect
{
    private int _damage;

    public ExtraDamageEffect(Unit unit, int damage, EffectDuration effectDuration)
    {
        base.Unit = unit;
        base.EffectDuration = effectDuration;
        _damage = damage;

    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectInfo extraDamageEffectsInfo = effectsSummary.ExtraDamageInfo;
        DamageEffectStatus extraDamageInfo = extraDamageEffectsInfo.GetDamageInfo(EffectDuration);
        extraDamageInfo.Active = true;  
        extraDamageInfo.Damage += _damage;
        extraDamageEffectsInfo.SetDamageInfo(EffectDuration, extraDamageInfo); 
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}