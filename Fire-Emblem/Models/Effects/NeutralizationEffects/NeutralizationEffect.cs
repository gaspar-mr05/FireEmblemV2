using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class NeutralizationEffect : Effect
{
    protected readonly string StatName;

    protected NeutralizationEffect(Unit unit, string statName) : base(unit)
    {
        StatName = statName;
    }

    public override void ApplyEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        EffectsCollection targetEffects = GetTargetEffects(activeEffectsInfo);

        targetEffects.RevertStatEffects(StatName);

        RegisterEffect();
    }

    protected abstract EffectsCollection GetTargetEffects(ActiveEffectsInfo activeEffectsInfo);
    protected abstract void RegisterEffect();

    public override int GetPriority() => 2;

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}