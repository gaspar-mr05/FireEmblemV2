using Fire_Emblem.Combat;
using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Effects.EffectSummary;
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

    protected string ExecuteAttack(Unit attacker, Unit defender)
    {
        DamageCalculator damageCalculator = new DamageCalculator(attacker, defender, RoundInfo);
        int newDamage = damageCalculator.GetDamageWithEffects();
        defender.Stats.SetStat("HP",  Math.Max(defender.Stats.GetHp() - newDamage, 0)); 
        int hpHealed = HealingApplier.HealAttacker(attacker, newDamage);
        RegisterAttack(attacker);
        AttackMessageGenerator attackMessageGenerator = new AttackMessageGenerator(attacker, defender, newDamage, hpHealed);
        return attackMessageGenerator.GenerateAttackMessage();
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

