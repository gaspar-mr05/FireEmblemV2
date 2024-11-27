using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public abstract class DamageEffectsManager
{
    protected Unit Attacker;
    protected Unit Defender;

    public abstract int ApplyDamageEffects(double damage, RoundInfo roundInfo);
}

