using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.FirstAttackEffects;

public abstract class FirstAttackEffect : Effect
{
    protected int Change;

    protected FirstAttackEffect(Unit unit, string statName, int change) : base(unit)
    {
        StatName = statName;
        Change = change;
    }
    
    protected abstract NormalEffectInfo GetFirstAttackInfo(EffectsSummary effectsSummary);
    protected abstract EffectsCollection GetEffects(ActiveEffectsInfo activeEffectsInfo);
    protected abstract int GetAdjustedChange();

    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        NormalEffectInfo firstAttackInfo = GetFirstAttackInfo(effectsSummary);
        
        firstAttackInfo.SetActiveTrue(StatName);
        firstAttackInfo.SaveChange(StatName, GetAdjustedChange());
        
        GetEffects(Unit.ActiveEffectsInfo).AddEffect(this);
    }

    public override void RevertEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        NormalEffectInfo firstAttackInfo = GetFirstAttackInfo(effectsSummary);
        
        firstAttackInfo.SetActiveFalse(StatName);
        
        GetEffects(Unit.ActiveEffectsInfo).RemoveEffect(this);
    }

    public override int GetPriority() => 1;
}
