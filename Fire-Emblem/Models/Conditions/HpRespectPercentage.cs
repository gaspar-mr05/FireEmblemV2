using Fire_Emblem.Conditions;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

public class HpRespectPercentage: ICondition
{
    private double _maxPercentage;
    private Unit _unit;
    private ComparisonType _comparisonType;
    private RoundInfo _roundInfo;

    public HpRespectPercentage(Unit unit, double maxPercentage, ComparisonType comparisonType, RoundInfo roundInfo)
    {
        _maxPercentage = maxPercentage;
        _unit= unit;
        _comparisonType = comparisonType;
        _roundInfo = roundInfo;

    }
    public bool IsConditionMet()
    {
        Stats initialStats = _roundInfo.InitialUnitsStats.GetInitialStats(_unit);
        CharacterInfo characterInfo = _unit.CharacterInfo;
        if (_comparisonType == ComparisonType.Less)
            return initialStats.GetHp() <= Convert.ToInt32(characterInfo.HP) * _maxPercentage;
        if (_comparisonType == ComparisonType.Greater)
            return Math.Round((double)initialStats.GetHp() / Convert.ToInt32(characterInfo.HP), 2) >= _maxPercentage;
        throw new ComparisonTypeException();
    }
}