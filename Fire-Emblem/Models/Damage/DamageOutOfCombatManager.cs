using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public static class DamageOutOfCombatManager
{

    public static DamageOutOfCombatInfo[] ApplyDamageOutOfCombat(Unit attacker, Unit defender, EffectDuration effectDuration)
    {
        return new []{ApplyDamageOutOfCombat(attacker, effectDuration), ApplyDamageOutOfCombat(defender, effectDuration)};
    }
   

    private static DamageOutOfCombatInfo ApplyDamageOutOfCombat(Unit unit, EffectDuration effectDuration)
    {
        DamageEffectInfo damageEffectInfo = unit.EffectsSummary.OutOfCombatDamageInfo;
        if (unit.IsAlive())
        {
            if (damageEffectInfo.GetDamageInfo(effectDuration).Active)
            {
                int damage = damageEffectInfo.GetDamageInfo(effectDuration).Damage;
                int newHp = CalculateNewHp(unit, damage);
                unit.Stats.SetStat("HP", newHp);
                return new DamageOutOfCombatInfo(unit, effectDuration, damage, newHp);
            }
            
        }
        return new DamageOutOfCombatInfo(unit, effectDuration, 0, 0);
    
    }
    


    private static int CalculateNewHp(Unit unit, int damage)
    {
        int maxHp = Convert.ToInt32(unit.CharacterInfo.HP);
        return Math.Min(maxHp, Math.Max(1, unit.Stats.GetHp() + damage));
    }


}