using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class FirstAttackExecutor : AttackExecutor
{


    public FirstAttackExecutor(RoundInfo roundInfo)
        : base(roundInfo)
    {
    }

    public AttackInfo ExecuteAttack(Unit attacker, Unit defender)
    {
        RoundInfo.AttackType = AttackType.FirstAttack;
        return base.ExecuteAttack(attacker, defender);
    }
    
}

    
