using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Unit;

namespace Fire_Emblem.Combat;
using Fire_Emblem.Characters;

public class RoundInfo
{
    public Unit Attacker;
    public Unit Defender;
    public InitialUnitStats InitialUnitsStats;
    public UnitAttacksCount UnitAttacksCount;
    public AttackType AttackType;

    public RoundInfo(Unit attacker, Unit defender)
    {
        
        Attacker = attacker;
        Defender = defender;
        InitialUnitsStats = new InitialUnitStats(attacker, defender);
        UnitAttacksCount = new UnitAttacksCount(attacker, defender);

    }
    
    public bool AreBothUnitsAlive()
    {
        if (Attacker.IsAlive() && Defender.IsAlive())
            return true;
        return false;
    }
    

    public bool IsRoundStart()
    {
        return !UnitAttacksCount.HasUnitAttacked(Attacker) && !UnitAttacksCount.HasUnitAttacked(Defender);
    }
    


}