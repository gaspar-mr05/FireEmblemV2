using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.DamageEffects;

public class ReductionOfReductionDamageEffect: Effect
{
    private double _reduction;

    public ReductionOfReductionDamageEffect(Unit unit, double reduction): base(unit)
    {
        _reduction = reduction;
    }
    public override void ApplyEffect()
    {
        ReduceReduction(EffectDuration.FirstAttack);
        ReduceReduction(EffectDuration.FollowUp);
        ReduceReduction(EffectDuration.FullRound);
    }

    private void ReduceReduction(EffectDuration effectDuration)
    {
        
        PercentageDamageEffectInfo percentageDamageEffectInfo = Unit.EffectsSummary.PercentageDamageReductionInfo;
        PercentageEffectStatus percentageEffectStatus =
            percentageDamageEffectInfo.GetPercentageReduction(effectDuration);
        percentageEffectStatus.ReductionOfReduction *= _reduction;
        
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }

    public override int GetPriority() => 3;
}