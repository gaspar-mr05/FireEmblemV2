using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Exceptions;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

public class FullHp: ICondition
{
    private Unit _unit;
    private ComparisonType _comparisonType;
    
    public FullHp(Unit unit, ComparisonType comparisonType)
    {
        _unit = unit;
        _comparisonType = comparisonType;
    }

    public bool IsConditionMet()
    {
        CharacterInfo characterInfo = _unit.CharacterInfo;
        int maxHp = Convert.ToInt32(characterInfo.HP);
        int currentHp = _unit.Stats.GetHp();
        
        if (_comparisonType == ComparisonType.FullHp)
            return currentHp == maxHp;
        else if (_comparisonType == ComparisonType.NotFullHp)
            return currentHp != maxHp;
        throw new ComparisonTypeException();
    }
    
}