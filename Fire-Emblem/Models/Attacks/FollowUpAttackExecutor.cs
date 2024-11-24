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
        RoundInfo.AttackType = AttackType.FollowUpAttack;

        if (!RoundInfo.AreBothUnitsAlive())
            return string.Empty;

        if (IsFollowUpPossible(attacker, defender))
            return ExecuteFollowUp(attacker, defender);

        if (IsNegatedCounterAttack(defender))
            return $"{attacker.CharacterInfo.Name} no puede hacer un follow up";

        if (IsFollowUpPossible(defender, attacker))
            return ExecuteFollowUp(defender, attacker);

        return "Ninguna unidad puede hacer un follow up";
    }
    
    private bool IsFollowUpPossible(Unit attacker, Unit defender) =>
        (attacker.Stats.GetSpd() - defender.Stats.GetSpd() >= 5 && defender.Stats.GetHp() > 0 && 
        !IsNegatedFollowUp(attacker)) || HasFollowUpGuaranteed(attacker);
    
    private bool IsNegatedFollowUp(Unit attacker)
    {
        
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        if (effectsSummary.PermitedAttackInfo.IsNegated(AttackType.FollowUpAttack))
            return true;
        if (effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack))
            return !RoundInfo.UnitAttacksCount.HasUnitAttacked(attacker);
        return false;
    }

    private string ExecuteFollowUp(Unit firstAttacker, Unit secondDefender)
    {
        string message = base.ExecuteAttack(firstAttacker, secondDefender);

        if (HasFollowUpGuaranteed(secondDefender))
        {
            message += $"\n{base.ExecuteAttack(secondDefender, firstAttacker)}";
        }

        return message;
    }
    

    private bool HasFollowUpGuaranteed(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        return effectsSummary.PermitedAttackInfo.IsGuaranteed(AttackType.FollowUpAttack);
    }
    
    

}
