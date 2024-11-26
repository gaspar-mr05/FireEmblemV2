using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects;

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
