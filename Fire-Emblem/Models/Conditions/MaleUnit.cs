using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

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