using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;

public abstract class OutOfCombatDamageEffect: Effect
{

    private int _damage;
    protected EffectDuration EffectDuration;

    protected OutOfCombatDamageEffect(Unit unit, int damage): base(unit)
    {
        _damage = damage;
    }
    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        DamageEffectStatus damageEffectStatus = effectsSummary.OutOfCombatDamageInfo.GetDamageInfo(EffectDuration);
        ApplyDamageOrHealing(damageEffectStatus);
    }

    private void ApplyDamageOrHealing(DamageEffectStatus damageEffectStatus)
    {
        damageEffectStatus.Active = true;
        damageEffectStatus.Damage += _damage;
    }
    

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    

}