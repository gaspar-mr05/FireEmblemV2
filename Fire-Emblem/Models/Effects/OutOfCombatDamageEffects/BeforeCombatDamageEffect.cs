using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;

public class BeforeCombatDamageEffect: OutOfCombatDamageEffect
{

    public BeforeCombatDamageEffect(Characters.Unit unit, int damage) : base(unit, damage)
    {
        EffectDuration = EffectDuration.BeforeCombat;
    }
    
}