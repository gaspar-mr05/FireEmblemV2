using Fire_Emblem.Characters;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects;

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
