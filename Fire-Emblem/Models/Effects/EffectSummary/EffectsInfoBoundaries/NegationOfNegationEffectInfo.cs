using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.EffectsInfoBoundaries;

public class NegationOfNegationEffectInfo
{
    private Dictionary<AttackType, bool> _negationOfNegationEffectInfo;

    public NegationOfNegationEffectInfo()
    {
        _negationOfNegationEffectInfo = new Dictionary<AttackType, bool>
        {
            { AttackType.CounterAttack, false },
            { AttackType.FollowUpAttack, false },
        };
    }

    public bool IsNegationNegated(AttackType attackType) => _negationOfNegationEffectInfo[attackType];

    public void NegateNegation(AttackType attackType) => _negationOfNegationEffectInfo[attackType] = true;
}
