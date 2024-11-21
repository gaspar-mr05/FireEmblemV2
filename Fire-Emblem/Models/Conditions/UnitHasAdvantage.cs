using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Conditions;

public class UnitHasAdvantage: ICondition
{

    private Unit _unit;
    private Unit _rival;

    public UnitHasAdvantage(Unit unit, Unit rival)
    {
        _unit = unit;
        _rival = rival;
    }

    public bool IsConditionMet()
    {
        AdvantageManager advantageManager = new AdvantageManager(_unit, _rival);
        try
        {
            return (_unit == advantageManager.GetUnitWithAdvantage());

        }
        catch (NoUnitWithAdvantage)
        {
            return false;
        }
    }
}