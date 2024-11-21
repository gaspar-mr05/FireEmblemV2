using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class SandstormEffect: NormalEffect
{
    public SandstormEffect(Unit unit, string statName)
    {
        base.StatName = statName;
        base.Unit = unit;
    }
    public override void ApplyEffect()
    {
        CalculateChange();
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        if (Change >= 0)
            activeEffectsInfo.BonusEffects.AddEffect(this);
        else if (Change < 0)
            activeEffectsInfo.PenaltyEffects.AddEffect(this);
        RegisterEffect();
    }

    public override void RevertEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (Change >= 0)
        {
            activeEffectsInfo.BonusEffects.RemoveEffect(this);
            effectsSummary.FollowUpBonusEffectInfo.SetActiveFalse(StatName);
        }
        else if (Change < 0)
        {
            activeEffectsInfo.PenaltyEffects.RemoveEffect(this);
            effectsSummary.FollowUpPenaltyEffectInfo.SetActiveFalse(StatName);
        }
        
    }

    private void CalculateChange()
    {
        base.Change = (int)Math.Floor(1.5 * Convert.ToInt32(Unit.CharacterInfo.Def) - 
        Convert.ToInt32(Unit.CharacterInfo.Atk));
    }

    public void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (Change >= 0)
        {
            effectsSummary.FollowUpBonusEffectInfo.SetActiveTrue(StatName);
            effectsSummary.FollowUpBonusEffectInfo.SaveChange(StatName, Change);

        }
        else
        {
            effectsSummary.FollowUpPenaltyEffectInfo.SetActiveTrue(StatName);
            effectsSummary.FollowUpPenaltyEffectInfo.SaveChange(StatName,Change);
        }

    }
}