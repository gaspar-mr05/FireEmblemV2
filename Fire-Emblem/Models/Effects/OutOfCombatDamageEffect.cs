using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.DamageEffects;

namespace Fire_Emblem.Effects;

public class OutOfCombatDamageEffect: DamageEffect
{

    private int _damage;

    public OutOfCombatDamageEffect(Unit unit, int damage, EffectDuration effectDuration)
    {

        Unit = unit;
        _damage = damage;
        EffectDuration = effectDuration;


    }
    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectStatus damageEffectStatus = new DamageEffectStatus();
        damageEffectStatus.Active = true;
        damageEffectStatus.Damage = _damage;
        effectsSummary.OutOfCombatDamageInfo.SetDamageInfo(EffectDuration, damageEffectStatus);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    

}