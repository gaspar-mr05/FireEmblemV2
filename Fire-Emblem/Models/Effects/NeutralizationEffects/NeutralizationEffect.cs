using Fire_Emblem.Effects;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.NeutralizationEffects;

public abstract class NeutralizationEffect : Effect
{

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