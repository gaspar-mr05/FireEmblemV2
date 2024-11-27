using Fire_Emblem.Combat;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public abstract class AttackEffectsManager
{
    protected Unit Attacker;
    protected Unit Defender;

    public abstract AttacksEffects GetAttackEffects();
}