using Fire_Emblem.Conditions;

namespace Fire_Emblem.Combat;
using Fire_Emblem.Characters;

public class RoundInfo
{
    public Unit UnitWhoStart;
    public Unit UnitWhoNotStart;
    public UnitAttacksCount UnitAttacksCount;
    public AttackType AttackType;

    public RoundInfo(Unit unitWhoStart, Unit unitWhoNotStart)
    {
        
        UnitWhoStart = unitWhoStart;
        UnitWhoNotStart = unitWhoNotStart;
        UnitAttacksCount = new UnitAttacksCount(unitWhoStart, unitWhoNotStart);

    }
    
    public bool AreBothUnitsAlive()
    {
        if (UnitWhoStart.IsAlive() && UnitWhoNotStart.IsAlive())
            return true;
        return false;
    }
    

    public bool IsRoundStart()
    {
        return !UnitAttacksCount.HasUnitAttacked(UnitWhoStart) && !UnitAttacksCount.HasUnitAttacked(UnitWhoNotStart);
    }
    


}