using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.FirstAttackEffects;

public class FirstAttackPenaltyEffect : FirstAttackEffect
{
    public FirstAttackPenaltyEffect(Unit unit, string statName, int change)
        : base(unit, statName, change) { }

    protected override NormalEffectInfo GetFirstAttackInfo(EffectsSummary effectsSummary)
    {
        return effectsSummary.FirstAttackPenaltiesInfo;
    }

    protected override EffectsCollection GetEffects(ActiveEffectsInfo activeEffectsInfo)
    {
        return activeEffectsInfo.PenaltyEffects;
    }

    protected override int GetAdjustedChange()
    {
        return -1 * Change; 
    }
}
