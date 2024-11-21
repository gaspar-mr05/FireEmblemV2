using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Combat;
using Fire_Emblem.Characters;
using Fire_Emblem_View;

public class FirstAttackExecutor : AttackExecutor
{


    public FirstAttackExecutor(RoundInfo roundInfo)
        : base(roundInfo)
    {
    }

    public string ExecuteAttack(Unit attacker, Unit defender)
    {
        RoundInfo.AttackType = AttackType.FirstAttack;
        string attackMessage = base.ExecuteAttack(attacker, defender);
        return attackMessage;
    }
    
}

    
