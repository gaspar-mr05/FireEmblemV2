using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NormalEffects;

public class BonusEffect : NormalEffect
{

    public BonusEffect(Unit unit, string statName, int change): base(unit, statName, change){}

    public override void ApplyEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        Unit.Stats.AddChange(StatName, Change);
        activeEffectsInfo.BonusEffects.AddEffect(this);
        RegisterEffect();
    }

    public override void RevertEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        Unit.Stats.AddChange(StatName, -Change);
        Unit.EffectsSummary.BonusesInfo.SetActiveFalse(StatName);
        activeEffectsInfo.BonusEffects.RemoveEffect(this);
    }

    private void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (effectsSummary.BonusesInfo.IsContainingStatName(StatName))
        {
            effectsSummary.BonusesInfo.SaveChange(StatName, Change);
            effectsSummary.BonusesInfo.SetActiveTrue(StatName);
        }
    }
    
}
    
