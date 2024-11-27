using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NeutralizationEffects;

public class PenaltyNeutralizationEffect : NeutralizationEffect
{
    public PenaltyNeutralizationEffect(Unit unit, string statName) : base(unit, statName)
    { }

    protected override EffectsCollection GetTargetEffects(ActiveEffectsInfo activeEffectsInfo)
    {
        return activeEffectsInfo.PenaltyEffects;
    }

    protected override void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PenaltyNeutralizationsInfo.SetActiveTrue(StatName);
    }
}
