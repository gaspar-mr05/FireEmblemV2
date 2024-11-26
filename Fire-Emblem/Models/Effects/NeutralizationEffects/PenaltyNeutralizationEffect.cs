using Fire_Emblem_View;
using Fire_Emblem.Characters;


namespace Fire_Emblem.Effects;

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
