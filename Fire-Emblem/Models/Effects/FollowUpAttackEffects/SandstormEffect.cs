using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.FollowUpAttackEffects;

public class SandstormEffect: Effect
{

    private int _change;
    public SandstormEffect(Unit unit, string statName): base(unit)
    {
        base.StatName = statName;
        base.Unit = unit;
    }
    public override void ApplyEffect()
    {
        CalculateChange();
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        if (_change >= 0)
            activeEffectsInfo.BonusEffects.AddEffect(this);
        else if (_change < 0)
            activeEffectsInfo.PenaltyEffects.AddEffect(this);
        RegisterEffect();
    }

    public override void RevertEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (_change >= 0)
        {
            activeEffectsInfo.BonusEffects.RemoveEffect(this);
            effectsSummary.FollowUpBonusesInfo.SetActiveFalse(StatName);
        }
        else if (_change < 0)
        {
            activeEffectsInfo.PenaltyEffects.RemoveEffect(this);
            effectsSummary.FollowUpPenaltiesInfo.SetActiveFalse(StatName);
        }
        
    }

    private void CalculateChange()
    {
        _change = (int)Math.Floor(1.5 * Convert.ToInt32(Unit.CharacterInfo.Def) - 
        Convert.ToInt32(Unit.CharacterInfo.Atk));
    }

    private void RegisterEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        if (_change >= 0)
        {
            effectsSummary.FollowUpBonusesInfo.SetActiveTrue(StatName);
            effectsSummary.FollowUpBonusesInfo.SaveChange(StatName, _change);

        }
        else
        {
            effectsSummary.FollowUpPenaltiesInfo.SetActiveTrue(StatName);
            effectsSummary.FollowUpPenaltiesInfo.SaveChange(StatName,_change);
        }

    }

    public override int GetPriority() => 1;
}