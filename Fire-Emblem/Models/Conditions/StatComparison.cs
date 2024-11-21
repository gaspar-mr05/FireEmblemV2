

using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Conditions;

public class StatComparison: ICondition
{
    private int _plus;
    private Unit _unit;
    private Unit _rival;
    private string _unitStatName;
    private string _rivalStatName;
    private ComparisonType _comparisonType;

    public StatComparison(Unit unit, Unit rival, string unitStatName, string rivalStatName, int plus, ComparisonType comparisonType)
    {
        _plus = plus;
        _unit = unit;
        _rival = rival;
        _unitStatName = unitStatName;
        _rivalStatName = rivalStatName;
        _comparisonType = comparisonType;
    }

    public bool IsConditionMet()
    {
        if (_comparisonType == ComparisonType.Greater)
            return (_unit.Stats.GetStat(_unitStatName) >= _rival.Stats.GetStat(_rivalStatName) + _plus);
        else if (_comparisonType == ComparisonType.Less)
            return (_unit.Stats.GetStat(_unitStatName) <= _rival.Stats.GetStat(_rivalStatName) + _plus);
        else if (_comparisonType == ComparisonType.StrictlyGreater)
            return  (_unit.Stats.GetStat(_unitStatName) > _rival.Stats.GetStat(_rivalStatName) + _plus);
        else if (_comparisonType == ComparisonType.StrictlyLess)
            return  (_unit.Stats.GetStat(_unitStatName) < _rival.Stats.GetStat(_rivalStatName)+ _plus);
        throw new ComparisonTypeException();
    }
}