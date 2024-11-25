using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.NegationEffects;

public class NegationOfGuaranteeEffect: Effect
{
    protected AttackType AttackType;
    
    public NegationOfGuaranteeEffect(Unit unit, AttackType attackType)
    {

        Unit = unit;
        AttackType = attackType;
    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PermitedAttackInfo.NegateGuarantee(AttackType);
    }
    
    

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }


    public override int GetPriority() => 7;
}