using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NegationEffects;

public class NegationOfGuaranteeEffect: Effect
{
    protected AttackType AttackType;
    
    public NegationOfGuaranteeEffect(Unit unit, AttackType attackType): base(unit)
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