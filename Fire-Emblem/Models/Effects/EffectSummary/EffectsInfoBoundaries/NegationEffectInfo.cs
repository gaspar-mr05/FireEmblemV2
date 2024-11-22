using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class NegationEffectInfo
{
    private Dictionary<AttackType, NegationEffectStatus> _negationEffectInfo;

    public NegationEffectInfo()
    {
        _negationEffectInfo = new Dictionary<AttackType, NegationEffectStatus>
        {
            { AttackType.CounterAttack, new NegationEffectStatus() },
            { AttackType.FollowUpAttack, new NegationEffectStatus() },
        };
    }

    public bool IsNegated(AttackType attackType) => _negationEffectInfo[attackType].Negated;

    public void NegateAttack(AttackType attackType)
    {
        _negationEffectInfo[attackType].Negated = true;
        _negationEffectInfo[attackType].Amount += 1;

    }
}