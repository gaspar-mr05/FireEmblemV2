

namespace Fire_Emblem.Models.Units;

public class UnitAttacksCount
{
    private Dictionary<Unit, int> attacksCountDict;


    public UnitAttacksCount(Unit unitWhoStart, Unit unitWhoNotStart)
    {
        attacksCountDict = new Dictionary<Unit, int>()
        {
            { unitWhoStart, 0 },
            { unitWhoNotStart, 0 }
        };
    }
    
    public bool HasUnitAttacked(Unit unit)
    {
        return attacksCountDict[unit] != 0;
    }

    public void AddAttack(Unit unit)
    {
        attacksCountDict[unit] += 1;
    }
    
}