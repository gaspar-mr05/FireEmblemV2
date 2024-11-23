using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects.DamageEffects;

public class DivineRecreationEffect: DamageEffect
{
    private Unit _rival;
    private RoundInfo _roundInfo;

    public DivineRecreationEffect(Unit unit, Unit rival, RoundInfo roundInfo)
    {
        base.Unit = unit;
        _rival = rival;
        _roundInfo = roundInfo;
    }

    public override void ApplyEffect()
    {
        DamageCalculator damageCalculator = new DamageCalculator(_rival, Unit, _roundInfo);
        int damageWithoutReduction = Convert.ToInt32(Math.Floor(damageCalculator.CalculateDamage()));
        ExtraDamageEffect extraDamageEffect;
        int reduction = -1 * (CalculateDamageReduction(damageWithoutReduction));
        if (_roundInfo.Attacker == Unit)
            extraDamageEffect = new ExtraDamageEffect(Unit, reduction, EffectDuration.FollowUp);
        else 
            extraDamageEffect = new ExtraDamageEffect(Unit, reduction, EffectDuration.FirstAttack);
        
        extraDamageEffect.ApplyEffect();
    }



    private int CalculateDamageReduction(int damage)
    {
        DamageEffectInfo rivalExtraDamageEffectInfo = _rival.EffectsSummary.ExtraDamageInfo;

        int extraDamage = rivalExtraDamageEffectInfo.GetDamageInfo(EffectDuration.FirstAttack).Damage + 
                          rivalExtraDamageEffectInfo.GetDamageInfo(EffectDuration.FullRound).Damage;

        DamageEffectsApplier damageEffectsApplier = new DamageEffectsApplier(_rival, Unit);
        int newDamage = damageEffectsApplier.ApplyDamageEffects(damage, _roundInfo);
        

        return Math.Min(newDamage - (damage + extraDamage), 0);
    }


    public override int GetPriority() => 4;

    
    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}