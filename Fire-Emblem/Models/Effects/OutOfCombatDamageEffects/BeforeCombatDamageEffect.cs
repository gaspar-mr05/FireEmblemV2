using Fire_Emblem.Effects;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;

public class BeforeCombatDamageEffect: OutOfCombatDamageEffect
{

    public BeforeCombatDamageEffect(Unit unit, int damage) : base(unit, damage)
    {
        EffectDuration = EffectDuration.BeforeCombat;
    }

    public override int GetPriority() => 3;
}