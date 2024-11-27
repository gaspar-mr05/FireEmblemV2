using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

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

    
