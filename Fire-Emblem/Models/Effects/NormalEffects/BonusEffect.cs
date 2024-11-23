using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Combat;

namespace Fire_Emblem.Effects;

public class BonusEffect : NormalEffect
{

    public BonusEffect(Unit unit, string statName, int change)
    {
        base.Unit = unit;
        base.StatName = statName;
        base.Change = change;
    }

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
        activeEffectsInfo.BonusEffects.RemoveEffect(this);
    }

    private void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (effectsSummary.BonusesInfo.IsContainingStatName(StatName))
            effectsSummary.BonusesInfo.SaveChange(StatName, Change);
    }
    
}
    
