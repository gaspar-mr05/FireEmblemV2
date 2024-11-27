using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

public class SumOfStatsComparison: ICondition
{
    private Unit _unit;
    private Unit _rival;
    private string _firstStat;
    private string _secondStat;

    public SumOfStatsComparison(Unit unit, Unit rival, string firstStat, string secondStat)
    {
        _unit = unit;
        _rival = rival;
        _firstStat = firstStat;
        _secondStat = secondStat;
    }

    public bool IsConditionMet()
    {
        return _unit.Stats.GetStat(_firstStat) + _unit.Stats.GetStat(_secondStat) > _rival.Stats.GetStat(_firstStat)
            + _rival.Stats.GetStat(_secondStat);
    }
}