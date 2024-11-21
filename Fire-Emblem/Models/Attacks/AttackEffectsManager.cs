using Fire_Emblem.Characters;

namespace Fire_Emblem.Combat;

public abstract class AttackEffectsManager
{
    protected Unit Attacker;
    protected Unit Defender;

    public abstract AttacksEffects GetAttackEffects();
}