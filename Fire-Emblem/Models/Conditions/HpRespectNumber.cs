using Fire_Emblem.Characters;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Conditions;

public class HpRespectNumber: ICondition
{
    private int _number;
    private Unit _unit;
    private ComparisonType _comparisonType;

    public HpRespectNumber(Unit unit, int number, ComparisonType comparisonType)
    {
        _unit= unit;
        _number = number;
        _comparisonType = comparisonType;

    }
    public bool IsConditionMet()
    {
        if (_comparisonType == ComparisonType.Less)
            return _unit.Stats.GetHp() <= _number;
        if (_comparisonType == ComparisonType.Greater)
            return _unit.Stats.GetHp() >= _number;
        throw new ComparisonTypeException();
    }
}