using Fire_Emblem.Characters;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Conditions;

public class StatBaseComparison: ICondition
{
    private int _plus;
    private Unit _unit;
    private Unit _rival;
    private string _unitStatName;
    private string _rivalStatName;
    private ComparisonType _comparisonType;

    public StatBaseComparison(Unit unit, Unit rival, string unitStatName, string rivalStatName, int plus, 
        ComparisonType comparisonType)
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
        int unitStat = Convert.ToInt32(_unit.CharacterInfo.GetInfoByName(_unitStatName));
        int rivalStat = Convert.ToInt32(_rival.CharacterInfo.GetInfoByName(_rivalStatName));
        if (_comparisonType == ComparisonType.Greater)
            return (unitStat >= rivalStat + _plus);
        else if (_comparisonType == ComparisonType.Less)
            return (unitStat <= rivalStat + _plus);
        else if (_comparisonType == ComparisonType.StrictlyGreater)
            return  (unitStat > rivalStat + _plus);
        else if (_comparisonType == ComparisonType.StrictlyLess)
            return  (unitStat < rivalStat + _plus);
        throw new ComparisonTypeException();
    }
}