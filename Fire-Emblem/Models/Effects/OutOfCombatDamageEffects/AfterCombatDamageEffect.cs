using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Models.Effects.DamageEffects;

public class AfterCombatDamageEffect: OutOfCombatDamageEffect
{
    

    public AfterCombatDamageEffect(Characters.Unit unit, int damage): base(unit, damage)
    {
        EffectDuration = EffectDuration.AfterCombat;
    }
    
    public override int GetPriority() => 7;
}