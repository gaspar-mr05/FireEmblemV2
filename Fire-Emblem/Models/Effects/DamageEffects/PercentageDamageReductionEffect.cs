using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.DamageEffects;

public class PercentageDamageReductionEffect: DamageEffect
{
    private double _percentage;


    public PercentageDamageReductionEffect(Unit unit, double percentage, EffectDuration effectDuration): base(unit, 
        effectDuration)
    {
        _percentage = percentage;
    }

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        PercentageDamageEffectInfo percentageDamageEffectInfo = effectsSummary.PercentageDamageReductionInfo;
        PercentageEffectStatus percentageReduction = percentageDamageEffectInfo.GetPercentageReduction(EffectDuration);
        percentageReduction.Active = true;
        percentageReduction.Percentage = 1 - ((1 - percentageReduction.Percentage) * (1 - _percentage * 
            percentageReduction.ReductionOfReduction));
    }



    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }

    public override int GetPriority() => 4;
}