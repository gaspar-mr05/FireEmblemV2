using Fire_Emblem.Characters;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Effects;

public abstract class FirstAttackEffect: NormalEffect
{
    protected abstract void AddToEffectsSummary(EffectsSummary effectsSummary);
    protected abstract void RemoveFromEffectsSummary(EffectsSummary effectsSummary);
    protected abstract void UpdateChange(EffectsSummary effectsSummary);

    public FirstAttackEffect(Unit unit, string statName, int change)
    {
        Unit = unit;
        StatName = statName;
        Change = change;
    }

    public override void ApplyEffect()
    {
        UpdateChange(Unit.EffectsSummary);
        AddToEffectsSummary(Unit.EffectsSummary);
    }

    public override void RevertEffect()
    {
        RemoveFromEffectsSummary(Unit.EffectsSummary);
    }
    
}