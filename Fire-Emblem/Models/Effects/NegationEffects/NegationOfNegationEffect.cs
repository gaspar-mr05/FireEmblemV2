using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.NegationEffects;

public class NegationOfNegationEffect: Effect
{
    protected AttackType AttackType;

    public NegationOfNegationEffect(Unit unit, AttackType attackType)
    {

        Unit = unit;
        AttackType = attackType;
    }

    public override void ApplyEffect()
    {
        if (IsAttackNegated() && AttackType == AttackType.CounterAttack)
        {
            NegateNegationAttackEffects(AttackType);
        }
        else if (AttackType == AttackType.FollowUpAttack)
        {
            NegateNegationAttackEffects(AttackType);
        }
    }
    
    
    private bool IsAttackNegated()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        return (effectsSummary.PermitedAttackInfo.IsNegated(AttackType)) ;
    }
    
    private void NegateNegationAttackEffects(AttackType attackType)
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PermitedAttackInfo.NegateNegation(attackType);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 6;
    
}