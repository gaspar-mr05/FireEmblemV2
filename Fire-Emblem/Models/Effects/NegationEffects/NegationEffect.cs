using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NegationEffects;

public class NegationEffect: Effect
{
    private AttackType _attackType;

    public NegationEffect(Unit unit, AttackType attackType): base(unit)
    {
        _attackType = attackType;
    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PermitedAttackInfo.NegateAttack(_attackType);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 6;
}