using Fire_Emblem.Characters;
using Fire_Emblem.Combat;

namespace Fire_Emblem.Conditions;

public class RecentRival: ICondition
{
    private Unit _unit;
    private Unit _rival;

    public RecentRival(Unit unit, Unit rival)
    {
        _unit = unit;
        _rival = rival;
    }
    public bool IsConditionMet()
    {
        if (_rival == _unit.UnitRoundsInfo.LastRival)
            return true;
        return false;
    }
}