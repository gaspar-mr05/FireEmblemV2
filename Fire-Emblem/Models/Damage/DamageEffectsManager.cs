using System.Data;
using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Combat;

public abstract class DamageEffectsManager
{
    protected Unit Attacker;
    protected Unit Defender;

    public abstract int ApplyDamageEffects(double damage, RoundInfo roundInfo);
}

