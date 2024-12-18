using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Round;

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

    public bool AreBothUnitsAlive() => Attacker.IsAlive() && Defender.IsAlive();


    public bool IsRoundStart() => !UnitAttacksCount.HasUnitAttacked(Attacker) &&
                                  !UnitAttacksCount.HasUnitAttacked(Defender);




}