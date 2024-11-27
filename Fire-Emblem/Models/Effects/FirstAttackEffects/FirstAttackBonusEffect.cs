using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.FirstAttackEffects;

public class FirstAttackBonusEffect : FirstAttackEffect
{
    public FirstAttackBonusEffect(Unit unit, string statName, int change)
        : base(unit, statName, change) { }

    protected override NormalEffectInfo GetFirstAttackInfo(EffectsSummary effectsSummary)
    {
        return effectsSummary.FirstAttackBonusesInfo;
    }

    protected override EffectsCollection GetEffects(ActiveEffectsInfo activeEffectsInfo)
    {
        return activeEffectsInfo.BonusEffects;
    }

    protected override int GetAdjustedChange()
    {
        return Change; 
    }
}

