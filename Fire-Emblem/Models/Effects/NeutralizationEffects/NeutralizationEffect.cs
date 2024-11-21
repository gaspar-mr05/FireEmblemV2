using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class NeutralizationEffect: Effect
{
    protected Unit Unit;
    protected string StatName;

    protected abstract void NeutralizeEffect(ActiveEffectsInfo activeEffectsInfo);
    protected abstract void RegisterEffect();
    public NeutralizationEffect(Unit unit, string statName)
    {
        Unit = unit;
        StatName = statName;
    }

    public override void ApplyEffect()
    {
        ActiveEffectsInfo activeEffectsInfo = Unit.ActiveEffectsInfo;
        NeutralizeEffect(activeEffectsInfo);
        RegisterEffect();
        
    }

    public override int GetPriority()
    {
        return 2;
    }
    
}