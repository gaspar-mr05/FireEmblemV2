using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class HealingApplier
{
    public static int HealAttacker(Unit attacker, int damageReceived)
    {
        EffectsSummary attackerEffectsSummary = attacker.EffectsSummary;
        int hpHealed = 0;
        if (CanBeHealed(attacker, attackerEffectsSummary))
        {
            hpHealed = Convert.ToInt32(Math.Floor(damageReceived * attackerEffectsSummary.ActiveHealingInfo.Percentage));
            attacker.Stats.SetStat("HP", Math.Min(attacker.Stats.GetHp() + hpHealed, 
                Convert.ToInt32(attacker.CharacterInfo.HP)));
        }
        return hpHealed;

    }
    
    private static bool CanBeHealed(Unit attacker, EffectsSummary attackerEffectsSummary)
    {
        return attackerEffectsSummary.ActiveHealingInfo.Active && attacker.IsAlive();
    }
}