using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Combat;

public class ReductionOfReductionDamageEffect: Effect
{
    private Unit _unit;
    private double _reduction;

    public ReductionOfReductionDamageEffect(Unit unit, double reduction)
    {
        _unit = unit;
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
        
        PercentageDamageEffectInfo percentageDamageEffectInfo = _unit.EffectsSummary.PercentageDamageReductionInfo;
        PercentageEffectStatus percentageEffectStatus =
            percentageDamageEffectInfo.GetPercentageReduction(effectDuration);
        percentageEffectStatus.Percentage *= _reduction;
        
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }

    public override int GetPriority() => 4;
}