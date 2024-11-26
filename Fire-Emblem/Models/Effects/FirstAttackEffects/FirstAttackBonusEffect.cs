using Fire_Emblem.Characters;
using Fire_Emblem_View;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects;

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

