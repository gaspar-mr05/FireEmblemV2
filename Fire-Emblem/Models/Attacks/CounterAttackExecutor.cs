using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;


public class CounterAttackExecutor : AttackExecutor
{

    public CounterAttackExecutor(RoundInfo roundInfo)
        : base(roundInfo) 
    {
    }

    public string ExecuteAttack(Unit attacker, Unit defender)
    {
        string attackMessage = "";
        RoundInfo.AttackType = AttackType.CounterAttack;
        if (IsCounterAttackPossible(defender))
            return base.ExecuteAttack(defender, attacker);
        return attackMessage;
    }

    private bool IsCounterAttackPossible(Unit unit)
    {
        if (RoundInfo.AreBothUnitsAlive())
            return !IsNegatedCounterAttack(unit);
        return false;

    }

    

}
