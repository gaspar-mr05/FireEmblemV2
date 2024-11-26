using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class PenaltyEffect: NormalEffect
{

    public PenaltyEffect(Unit unit, string statName, int change): base(unit, statName, change)
    {}

    public override void ApplyEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        Unit.Stats.AddChange(StatName, -Change);
        activeEffectsInfo.PenaltyEffects.AddEffect(this);
        RegisterEffect();
    }

    public override void RevertEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        Unit.Stats.AddChange(StatName, Change);
        Unit.EffectsSummary.PenaltiesInfo.SetActiveFalse(StatName);
        activeEffectsInfo.PenaltyEffects.RemoveEffect(this);
    }
    private void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (effectsSummary.PenaltiesInfo.IsContainingStatName(StatName))
        {
            effectsSummary.PenaltiesInfo.SaveChange(StatName, -Change);
            effectsSummary.PenaltiesInfo.SetActiveTrue(StatName);
        }

    }
}