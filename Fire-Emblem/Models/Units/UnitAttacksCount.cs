

namespace Fire_Emblem.Models.Units;

public class UnitAttacksCount
{
    private Dictionary<Unit, int> _attacksCountDict;


    public UnitAttacksCount(Unit unitWhoStart, Unit unitWhoNotStart)
    {
        _attacksCountDict = new Dictionary<Unit, int>()
        {
            { unitWhoStart, 0 },
            { unitWhoNotStart, 0 }
        };
    }
    
    public bool HasUnitAttacked(Unit unit)
    {
        return _attacksCountDict[unit] != 0;
    }

    public void AddAttack(Unit unit)
    {
        _attacksCountDict[unit] += 1;
    }
    
}