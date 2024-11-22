using Fire_Emblem_View;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Combat;
using Fire_Emblem.Characters;


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
        int hpHealed = CurateAttacker(attacker, newDamage);
        RegisterAttack(attacker);
        AttackMessageGenerator attackMessageGenerator = new AttackMessageGenerator(attacker, defender, newDamage, hpHealed);
        return attackMessageGenerator.GenerateAttackMessage();
    }

    private int CurateAttacker(Unit attacker, int damageReceived)
    {
        EffectsSummary attackerEffectsSummary = attacker.EffectsSummary;
        int hpHealed = 0;
        if (CanBeHealed(attacker, attackerEffectsSummary))
        {
            hpHealed = Convert.ToInt32(Math.Floor(damageReceived * attackerEffectsSummary.HealingEffectActive.Percentage));
            attacker.Stats.SetStat("HP", Math.Min(attacker.Stats.GetHp() + hpHealed, 
                Convert.ToInt32(attacker.CharacterInfo.HP)));
        }
        return hpHealed;

    }
    
    private bool CanBeHealed(Unit attacker, EffectsSummary attackerEffectsSummary)
    {
        return attackerEffectsSummary.HealingEffectActive.Active && attacker.Stats.GetHp() > 0;
    }

    private void RegisterAttack(Unit attacker)
    {
        RoundInfo.UnitAttacksCount.AddAttack(attacker);
    }


    
    
    
    

}

