using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Combat;

public class FollowUpAttackExecutor : AttackExecutor
{


    public FollowUpAttackExecutor(RoundInfo roundInfo)
        : base(roundInfo)
    {
    }

    public string ExecuteAttack(Unit attacker, Unit defender)
    {
        string attackMessage = "";
        RoundInfo.AttackType = AttackType.FollowUpAttack;
        if (RoundInfo.AreBothUnitsAlive())
        {
            
            if (IsFollowUpPossible(attacker,defender))
                return base.ExecuteAttack(attacker, defender);
            else
            {
                if (IsNegatedCounterAttack(defender))
                    return $"{attacker.CharacterInfo.Name} no puede hacer un follow up";
            }
            if (IsFollowUpPossible(defender, attacker))
                return base.ExecuteAttack(defender, attacker);
            
            if (!IsFollowUpPossible(attacker, defender) && !IsFollowUpPossible(defender, attacker))
                return "Ninguna unidad puede hacer un follow up";
           
        }
        ApplyAfterCombatDamage(attacker);
        ApplyAfterCombatDamage(defender);
        return attackMessage;
    }

    private bool IsFollowUpPossible(Unit attacker, Unit defender) =>
        attacker.Stats.GetSpd() - defender.Stats.GetSpd() >= 5 && defender.Stats.GetHp() > 0 && 
        !IsNegatedFollowUp(attacker);
    
    
    private bool IsNegatedFollowUp(Unit attacker)
    {
        
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        if (effectsSummary.NegationAttacksInfo.IsNegated(AttackType.FollowUpAttack))
            return true;
        if (effectsSummary.NegationAttacksInfo.IsNegated(AttackType.CounterAttack))
            return !RoundInfo.UnitAttacksCount.HasUnitAttacked(attacker);
        return false;
    }

    private void ApplyAfterCombatDamage(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        DamageEffectStatus damageEffectStatus =
            effectsSummary.OutOfCombatDamageInfo.GetDamageInfo(EffectDuration.AfterCombat);
        if (damageEffectStatus.Active)
            if (unit.IsAlive())
                unit.Stats.SetStat("HP", Math.Max(unit.Stats.GetHp() - damageEffectStatus.Damage, 1));
            else
                damageEffectStatus.Active = false;
    }
    

}
