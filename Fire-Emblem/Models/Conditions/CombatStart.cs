using Fire_Emblem.Models.Round;

namespace Fire_Emblem.Models.Conditions;

public class CombatStart: ICondition
{
    private RoundInfo _roundInfo;

    public CombatStart(RoundInfo roundInfo)
    {
        _roundInfo = roundInfo;

    }
    public bool IsConditionMet()
    {
        if (_roundInfo.IsRoundStart())
            return true;
        return false;
    }
}