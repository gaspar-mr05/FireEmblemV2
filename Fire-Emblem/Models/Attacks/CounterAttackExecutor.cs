using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Combat;


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
        if (RoundInfo.AreBothUnitsAlive())
        {
            attackMessage = base.ExecuteAttack(defender, attacker);
            
        }
        return attackMessage;
    }
}
