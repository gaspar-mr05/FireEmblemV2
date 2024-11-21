using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Combat;

public class AttackEffectsManagerBuilder
{
    private RoundInfo _roundInfo;
    private Unit _attacker;
    private Unit _defender;
    
    public AttackEffectsManagerBuilder(Unit attacker, Unit defender, RoundInfo roundInfo)
    {
        _roundInfo = roundInfo;
        _attacker = attacker;
        _defender = defender;
    }

    public AttackEffectsManager BuildAttackEffectsManager()
    {

        if (!_roundInfo.UnitAttacksCount.HasUnitAttacked(_attacker))
            return (new FirstAttackEffectsManager(_attacker, _defender));
        if (_roundInfo.AttackType is AttackType.FollowUpAttack)
        {
            return new FollowUpEffectsManager(_attacker);
        }
        else
        {
            throw new NoRoundInfoException();
        }

    }
}