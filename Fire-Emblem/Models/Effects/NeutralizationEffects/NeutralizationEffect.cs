using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class NeutralizationEffect: Effect
{
    

    protected abstract void NeutralizeEffect(ActiveEffectsInfo activeEffectsInfo);
    protected abstract void RegisterEffect();
    public NeutralizationEffect(Unit unit, string statName): base(unit)
    {
        StatName = statName;
    }

    public override void ApplyEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        NeutralizeEffect(activeEffectsInfo);
        RegisterEffect();
        
    }

    public override int GetPriority() => 2;

}