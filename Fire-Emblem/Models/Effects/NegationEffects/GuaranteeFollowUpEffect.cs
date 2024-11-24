using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.NegationEffects;

public class GuaranteeFollowUpEffect: Effect
{

    protected AttackType AttackType;

    public GuaranteeFollowUpEffect(Unit unit)
    {
        Unit = unit;
        AttackType = AttackType.FollowUpAttack;
    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PermitedAttackInfo.GuaranteeAttack(AttackType);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 5;
}