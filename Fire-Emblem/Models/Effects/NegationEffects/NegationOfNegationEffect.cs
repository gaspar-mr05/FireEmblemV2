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
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (IsAttackNegated())
        {
            effectsSummary.NegationInfo.NegateNegation(AttackType);
            effectsSummary.NegationOfNegationInfo.NegateNegation(AttackType);
        }
        
    }

    private bool IsAttackNegated()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        return (effectsSummary.NegationInfo.IsNegated(AttackType)) ;
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 6;
    
}