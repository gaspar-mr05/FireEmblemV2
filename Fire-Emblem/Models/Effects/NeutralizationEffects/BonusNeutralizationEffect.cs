using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NeutralizationEffects;

public class BonusNeutralizationEffect : NeutralizationEffect
{
    public BonusNeutralizationEffect(Unit unit, string statName) : base(unit, statName)
    { }

    protected override EffectsCollection GetTargetEffects(ActiveEffectsInfo activeEffectsInfo)
    {
        return activeEffectsInfo.BonusEffects;
    }

    protected override void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.BonusNeutralizationsInfo.SetActiveTrue(StatName);
    }
}