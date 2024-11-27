using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

public class UnitStartCombat: ICondition
{
    private Unit _unit;
    private RoundInfo _roundInfo;

    public UnitStartCombat(Unit unit, RoundInfo roundInfo )
    {
        _unit = unit;
        _roundInfo = roundInfo;
    }

    public bool IsConditionMet()
    {
        if (_unit == _roundInfo.Attacker)
            return true;
        return false;
    }
    
    
}