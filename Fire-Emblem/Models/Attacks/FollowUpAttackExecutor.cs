using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Exceptions;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class FollowUpAttackExecutor : AttackExecutor
{


    public FollowUpAttackExecutor(RoundInfo roundInfo)
        : base(roundInfo)
    {
    }
    
    public (AttackInfo, AttackInfo) ExecuteAttack(Unit attacker, Unit defender)
    {
        if (!RoundInfo.AreBothUnitsAlive())
            return (new AttackInfo(attacker, defender, 0, 0, AttackError.NoAttackPossible), 
                new AttackInfo(defender, attacker, 0, 0, AttackError.NoAttackPossible));

        RoundInfo.AttackType = AttackType.FollowUpAttack;

        return (ExecuteFollowUp(attacker, defender), ExecuteFollowUp(defender, attacker));
        
    }

    private string ConcatenateMessage(string currentMessage, string newMessage)
    {
        return string.IsNullOrEmpty(newMessage) 
            ? currentMessage 
            : string.IsNullOrEmpty(currentMessage) 
                ? newMessage 
                : $"{currentMessage}\n{newMessage}";
    }

    
    

    private AttackInfo ExecuteFollowUp(Unit attacker, Unit defender)
    {
        
        if (RoundInfo.AreBothUnitsAlive())
        {
            if (IsFollowUpPossible(attacker, defender))
                return base.ExecuteAttack(attacker, defender);

            EffectsSummary effectsSummary = defender.EffectsSummary;
            if (!RoundInfo.UnitAttacksCount.HasUnitAttacked(defender) &&
                effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack))
                return new AttackInfo(attacker, defender, 0, 0, AttackError.NoFollowUpIndividual);
            
            if (!IsFollowUpPossible(attacker, defender))
                return new AttackInfo(attacker, defender, 0, 0, AttackError.NoFollowUpBoth);
                
        }
        return new AttackInfo(attacker, defender, 0, 0, AttackError.NoAttackPossible);
    }
    
    
    

    private bool IsFollowUpPossible(Unit attacker, Unit defender)
    {
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        int sum = 0;
        if (IsCheckSpeedConditionMet(attacker, defender))
            sum += 1;
        if (HasFollowUpGuaranteed(attacker))
            sum += effectsSummary.PermitedAttackInfo.GetAmountGuaranteed(AttackType.FollowUpAttack);
        if (HasFollowUpNegated(attacker))
            sum -= effectsSummary.PermitedAttackInfo.GetAmountNegated(AttackType.FollowUpAttack);
        return sum > 0;

    }


    private bool IsCheckSpeedConditionMet(Unit attacker, Unit defender)
    {
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        if (attacker.Stats.GetSpd() - defender.Stats.GetSpd() >= 5 && defender.Stats.GetHp() > 0
            && !(!RoundInfo.UnitAttacksCount.HasUnitAttacked(attacker) &&
                 effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack)))
            return true;
        return false;
    }
    
    private bool HasFollowUpGuaranteed(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        return effectsSummary.PermitedAttackInfo.IsGuaranteed(AttackType.FollowUpAttack);
    }
       
    
    
    
    private bool HasFollowUpNegated(Unit attacker)
    {
        
        EffectsSummary effectsSummary = attacker.EffectsSummary;
        if (effectsSummary.PermitedAttackInfo.IsNegated(AttackType.FollowUpAttack))
            return true;
        if (effectsSummary.PermitedAttackInfo.IsNegated(AttackType.CounterAttack))
            return !RoundInfo.UnitAttacksCount.HasUnitAttacked(attacker);
        return false;
    }
    
    

}
