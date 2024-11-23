using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.DamageEffects;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Combat;

public static class DamageOutOfCombatManager
{

    public static string[] ApplyDamageOutOfCombat(Unit attacker, Unit defender, EffectDuration effectDuration)
    {
        return new []{ApplyDamageOutOfCombat(attacker, effectDuration), ApplyDamageOutOfCombat(defender, effectDuration)};
    }
   

    private static string ApplyDamageOutOfCombat(Unit unit, EffectDuration effectDuration)
    {
        DamageEffectInfo damageEffectInfo = unit.EffectsSummary.OutOfCombatDamageInfo;
        if (unit.IsAlive())
        {
            if (damageEffectInfo.GetDamageInfo(effectDuration).Active)
            {
                int damage = damageEffectInfo.GetDamageInfo(effectDuration).Damage;
                int newHp = CalculateNewHp(unit, damage);
                unit.Stats.SetStat("HP", newHp);
                return GenerateMessage(unit, effectDuration, damage, newHp);
                
            }
            
        }

        return string.Empty;
    
    }



    private static int CalculateNewHp(Unit unit, int damage)
    {
        int maxHp = Convert.ToInt32(unit.CharacterInfo.HP);
        return Math.Min(maxHp, Math.Max(1, unit.Stats.GetHp() + damage));
    }

    private static string GenerateMessage(Unit unit, EffectDuration effectDuration, int damage, int newHp)
    {
        string damageType = effectDuration == EffectDuration.AfterCombat ? "despues del combate" : "antes de iniciar el combate";
        string finalHp = effectDuration == EffectDuration.AfterCombat ? "" : $" y queda con {newHp} HP";
        int absoluteDamage = Math.Abs(damage);
        string action = damage < 0 ? $"recibe {absoluteDamage} de daño" : $"recupera {absoluteDamage} HP";

        return $"{unit.CharacterInfo.Name} {action} {damageType}{finalHp}";
    }
}