using Fire_Emblem.Characters;
using Fire_Emblem.Combat;

namespace Fire_Emblem.Conditions;

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