using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.DamageEffects;

public abstract class DamageEffect: Effect
{
    protected EffectDuration EffectDuration;

    protected DamageEffect(Unit unit, EffectDuration effectDuration) : base(unit)
    {
        EffectDuration = effectDuration;
    }

    public override int GetPriority() => 3;

    
}