using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;

public class AfterCombatDamageEffect: OutOfCombatDamageEffect
{
    

    public AfterCombatDamageEffect(Unit unit, int damage): base(unit, damage)
    {
        EffectDuration = EffectDuration.AfterCombat;
    }
    
    public override int GetPriority() => 8;
}