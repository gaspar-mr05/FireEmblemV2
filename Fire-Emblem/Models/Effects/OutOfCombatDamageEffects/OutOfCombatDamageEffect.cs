using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.DamageEffects;

namespace Fire_Emblem.Effects;

public abstract class OutOfCombatDamageEffect: Effect
{

    private int _damage;
    protected EffectDuration EffectDuration;

    public OutOfCombatDamageEffect(Unit unit, int damage)
    {

        Unit = unit;
        _damage = damage;



    }
    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectStatus damageEffectStatus = effectsSummary.OutOfCombatDamageInfo.GetDamageInfo(EffectDuration);
        ApplyDamageOrHealing(damageEffectStatus);
    }

    protected void ApplyDamageOrHealing(DamageEffectStatus damageEffectStatus)
    {
        damageEffectStatus.Active = true;
        damageEffectStatus.Damage += _damage;
    }

    public override int GetPriority() => 3;

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    

}