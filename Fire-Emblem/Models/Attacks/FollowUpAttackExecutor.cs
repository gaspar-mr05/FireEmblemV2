using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

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
                attackMessage = base.ExecuteAttack(attacker, defender); 
            else if (IsFollowUpPossible(defender, attacker))
                attackMessage = base.ExecuteAttack(defender, attacker);
            else
                attackMessage = "Ninguna unidad puede hacer un follow up";
        }
        return attackMessage;
    }

    private bool IsFollowUpPossible(Unit attacker, Unit defender) =>
        attacker.Stats.GetSpd() - defender.Stats.GetSpd() >= 5 && defender.Stats.GetHp() > 0;

}
