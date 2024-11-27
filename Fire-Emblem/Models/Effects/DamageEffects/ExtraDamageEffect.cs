using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.DamageEffects;

public class ExtraDamageEffect: DamageEffect
{
    private int _damage;

    public ExtraDamageEffect(Unit unit, int damage, EffectDuration effectDuration): base(unit, effectDuration)
    {
        _damage = damage;

    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectInfo extraDamageEffectsInfo = effectsSummary.ExtraDamageInfo;
        DamageEffectStatus extraDamageInfo = extraDamageEffectsInfo.GetDamageInfo(EffectDuration);
        extraDamageInfo.Active = true;  
        extraDamageInfo.Damage += _damage;
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}