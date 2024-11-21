using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class FirstAttackPenaltyEffect : FirstAttackEffect
{
    public FirstAttackPenaltyEffect(Unit unit, string statName, int change) 
        : base(unit, statName, change) {}

    protected override void AddToEffectsSummary(EffectsSummary effectsSummary)
    {
        effectsSummary.FirstAttackPenaltyEffectInfo.SetActiveTrue(StatName);
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        activeEffectsInfo.PenaltyEffects.AddEffect(this);
    }
    

    protected override void RemoveFromEffectsSummary(EffectsSummary effectsSummary)
    {
        effectsSummary.FirstAttackPenaltyEffectInfo.SetActiveFalse(StatName);
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        activeEffectsInfo.PenaltyEffects.RemoveEffect(this);
    }

    protected override void UpdateChange(EffectsSummary effectsSummary)
    {
        effectsSummary.FirstAttackPenaltyEffectInfo.SaveChange(StatName, -1 * Change);
    }
}