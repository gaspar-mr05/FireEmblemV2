using Fire_Emblem.Characters;
using Fire_Emblem.Combat;

namespace Fire_Emblem.Conditions;

public class MaleUnit: ICondition
{
    private Unit _unit;

    public MaleUnit(Unit unit)
    {
        _unit = unit;
    }
    public bool IsConditionMet()
    {
        if (_unit.CharacterInfo.Gender == "Male")
            return true;
        return false;
    }
}