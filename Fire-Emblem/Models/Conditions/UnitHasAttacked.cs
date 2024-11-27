using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

public class UnitHasAttacked: ICondition
{

    private Unit _unit;
    private RoundInfo _roundInfo;

    public UnitHasAttacked(Unit unit, RoundInfo roundInfo)
    {
        _unit = unit;
        _roundInfo = roundInfo;

    }

    public bool IsConditionMet()
    {
        return _roundInfo.UnitAttacksCount.HasUnitAttacked(_unit);
    }
}