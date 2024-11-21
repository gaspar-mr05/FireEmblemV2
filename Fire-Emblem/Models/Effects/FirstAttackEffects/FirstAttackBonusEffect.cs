using Fire_Emblem.Characters;
using Fire_Emblem_View;

namespace Fire_Emblem.Effects;

public class FirstAttackBonusEffect : FirstAttackEffect
{
    public FirstAttackBonusEffect(Unit unit, string statName, int change) 
        : base(unit, statName, change) { }

    protected override void AddToEffectsSummary(EffectsSummary effectsSummary)
    {
        effectsSummary.FirstAttackBonusEffectInfo.SetActiveTrue(StatName);
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        activeEffectsInfo.BonusEffects.AddEffect(this);
        
    }

    protected override void RemoveFromEffectsSummary(EffectsSummary effectsSummary)
    {
        effectsSummary.FirstAttackBonusEffectInfo.SetActiveFalse(StatName);
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        activeEffectsInfo.BonusEffects.RemoveEffect(this);
    }

    protected override void UpdateChange(EffectsSummary effectsSummary)
    {
        effectsSummary.FirstAttackBonusEffectInfo.SaveChange(StatName, Change);
    }
}


