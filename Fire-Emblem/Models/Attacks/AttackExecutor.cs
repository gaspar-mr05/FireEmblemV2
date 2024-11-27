using Fire_Emblem.Combat;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class AttackExecutor
{
    protected RoundInfo RoundInfo;



    public AttackExecutor(RoundInfo roundInfo)
    {
        RoundInfo = roundInfo;
    }

    protected AttackInfo ExecuteAttack(Unit attacker, Unit defender)
    {
        DamageCalculator damageCalculator = new DamageCalculator(attacker, defender, RoundInfo);
        int newDamage = damageCalculator.GetDamageWithEffects();
        defender.Stats.SetStat("HP",  Math.Max(defender.Stats.GetHp() - newDamage, 0)); 
        int hpHealed = HealingApplier.HealAttacker(attacker, newDamage);
        RegisterAttack(attacker);
        return new AttackInfo(attacker, defender, newDamage, hpHealed, AttackError.NoError);
    }



    private void RegisterAttack(Unit attacker)
    {
        RoundInfo.UnitAttacksCount.AddAttack(attacker);
    }
    
    protected bool IsNegatedCounterAttack(Unit attacker)
    {
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        return effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack);

    }
    
    





    
    
    
    

}

