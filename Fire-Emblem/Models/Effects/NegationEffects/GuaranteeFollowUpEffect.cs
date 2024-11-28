using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NegationEffects;

public class GuaranteeFollowUpEffect: Effect
{

    private AttackType _attackType;

    public GuaranteeFollowUpEffect(Unit unit): base(unit)
    {
        _attackType = AttackType.FollowUpAttack;
    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PermitedAttackInfo.GuaranteeAttack(_attackType);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 6;
}