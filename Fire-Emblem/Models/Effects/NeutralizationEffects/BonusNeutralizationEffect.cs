using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

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