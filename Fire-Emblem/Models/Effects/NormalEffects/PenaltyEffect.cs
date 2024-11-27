using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NormalEffects;

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