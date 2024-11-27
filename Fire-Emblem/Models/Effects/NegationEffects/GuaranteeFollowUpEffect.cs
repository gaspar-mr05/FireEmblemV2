using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NegationEffects;

public class GuaranteeFollowUpEffect: Effect
{

    protected AttackType AttackType;

    public GuaranteeFollowUpEffect(Unit unit): base(unit)
    {
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


    public override int GetPriority() => 6;
}