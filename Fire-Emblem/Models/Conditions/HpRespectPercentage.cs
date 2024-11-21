using Fire_Emblem.Characters;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Conditions;

public class HpRespectPercentage: ICondition
{
    private double _maxPercentage;
    private Unit _unit;
    private ComparisonType _comparisonType;

    public HpRespectPercentage(Unit unit, double maxPercentage, ComparisonType comparisonType)
    {
        _maxPercentage = maxPercentage;
        _unit= unit;
        _comparisonType = comparisonType;

    }
    public bool IsConditionMet()
    {
        CharacterInfo characterInfo = _unit.CharacterInfo;
        if (_comparisonType == ComparisonType.Less)
            return _unit.Stats.GetHp() <= Convert.ToInt32(characterInfo.HP) * _maxPercentage;
        if (_comparisonType == ComparisonType.Greater)
            return Math.Round((double)_unit.Stats.GetHp() / Convert.ToInt32(characterInfo.HP), 2) >= _maxPercentage;
        throw new ComparisonTypeException();
    }
}