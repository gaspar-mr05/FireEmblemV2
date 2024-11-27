using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NegationEffects;

public class NegationOfNegationEffect: Effect
{
    protected AttackType AttackType;

    public NegationOfNegationEffect(Unit unit, AttackType attackType): base(unit)
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


    public override int GetPriority() => 7;
    
}