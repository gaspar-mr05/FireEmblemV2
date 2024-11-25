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
        string message = string.Empty;
        RoundInfo.AttackType = AttackType.FollowUpAttack;

        if (!RoundInfo.AreBothUnitsAlive())
            return message;

        message += string.IsNullOrEmpty(message) 
            ? ExecuteFollowUp(attacker, defender) 
            : $"\n{ExecuteFollowUp(attacker, defender)}";

        message += string.IsNullOrEmpty(message) 
            ? ExecuteFollowUp(defender, attacker) 
            : $"\n{ExecuteFollowUp(defender, attacker)}";

        if (string.IsNullOrEmpty(message))
            return "Ninguna unidad puede hacer un follow up";
        
        return message.TrimEnd('\n');
    }
    
    

    private string ExecuteFollowUp(Unit attacker, Unit defender)
    {
        string message = string.Empty;

        if (HasFollowUpGuaranteed(attacker))
            return base.ExecuteAttack(attacker, defender);

        if (IsFollowUpPossible(attacker, defender))
            return base.ExecuteAttack(attacker, defender);

        EffectsSummary effectsSummary = defender.EffectsSummary;
        if (!RoundInfo.UnitAttacksCount.HasUnitAttacked(defender) &&
            effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack))
            return $"{attacker.CharacterInfo.Name} no puede hacer un follow up";

        return message;
    }
    
    
    
    private bool HasFollowUpGuaranteed(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        return effectsSummary.PermitedAttackInfo.IsGuaranteed(AttackType.FollowUpAttack);
    }
    
    private bool IsFollowUpPossible(Unit attacker, Unit defender) =>
        attacker.Stats.GetSpd() - defender.Stats.GetSpd() >= 5 && defender.Stats.GetHp() > 0 && 
        !IsNegatedFollowUp(attacker);
    
    private bool IsNegatedFollowUp(Unit attacker)
    {
        
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        if (effectsSummary.PermitedAttackInfo.IsNegated(AttackType.FollowUpAttack))
            return true;
        if (effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack))
            return !RoundInfo.UnitAttacksCount.HasUnitAttacked(attacker);
        return false;
    }
    
    

}
