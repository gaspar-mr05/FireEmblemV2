using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.DamageEffects;

public abstract class DamageEffect: Effect
{
    protected EffectDuration EffectDuration;

    public override int GetPriority() => 3;

    
}