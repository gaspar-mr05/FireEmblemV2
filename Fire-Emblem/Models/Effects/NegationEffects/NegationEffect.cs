using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.NegationEffects;

public class NegationEffect: Effect
{
    protected AttackType AttackType;

    public NegationEffect(Unit unit, AttackType attackType)
    {

        Unit = unit;
        AttackType = attackType;
    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PermitedAttackInfo.NegateAttack(AttackType);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 6;
}