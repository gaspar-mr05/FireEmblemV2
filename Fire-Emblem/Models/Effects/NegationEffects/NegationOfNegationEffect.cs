using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NegationEffects;

public class NegationOfNegationEffect: Effect
{
    private AttackType _attackType;

    public NegationOfNegationEffect(Unit unit, AttackType attackType): base(unit)
    {

        Unit = unit;
        _attackType = attackType;
    }

    public override void ApplyEffect()
    {
        if (IsAttackNegated() && _attackType == AttackType.CounterAttack)
        {
            NegateNegationAttackEffects(_attackType);
        }
        else if (_attackType == AttackType.FollowUpAttack)
        {
            NegateNegationAttackEffects(_attackType);
        }
    }
    
    
    private bool IsAttackNegated()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        return (effectsSummary.PermitedAttackInfo.IsNegated(_attackType)) ;
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