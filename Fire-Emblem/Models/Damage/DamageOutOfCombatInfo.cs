using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class DamageOutOfCombatInfo
{
    public Unit Unit;
    public EffectDuration EffectDuration;
    public int Damage;
    public int NewHp;

    public DamageOutOfCombatInfo(Unit unit, EffectDuration effectDuration, int damage, int newHp)
    {
        Unit = unit;
        EffectDuration = effectDuration;
        Damage = damage;
        NewHp = newHp;
    }

}