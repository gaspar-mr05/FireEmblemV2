using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Exceptions;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;


public class CounterAttackExecutor : AttackExecutor
{

    public CounterAttackExecutor(RoundInfo roundInfo)
        : base(roundInfo) 
    {
    }

    public AttackInfo ExecuteAttack(Unit attacker, Unit defender)
    {
        RoundInfo.AttackType = AttackType.CounterAttack;
        if (IsCounterAttackPossible(defender))
            return base.ExecuteAttack(defender, attacker);
        return new AttackInfo(attacker, defender, 0, 0, AttackError.NoAttackPossible);
    }

    private bool IsCounterAttackPossible(Unit unit)
    {
        if (RoundInfo.AreBothUnitsAlive())
            return !IsNegatedCounterAttack(unit);
        return false;

    }

    

}
