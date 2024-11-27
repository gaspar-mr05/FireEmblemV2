using Fire_Emblem.Combat;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class AbsoluteDamageReductionEffectsManager: DamageEffectsManager
{
    public AbsoluteDamageReductionEffectsManager(Unit attacker, Unit defender)
    {

        base.Attacker = attacker;
        base.Defender = defender;
    }

    public override int ApplyDamageEffects(double damage, RoundInfo roundInfo)
    {
        DamageEffectInfo absoluteDamageInfo =
            Defender.EffectsSummary.AbsoluteDamageReductionInfo;
        
        double newDamage = damage + absoluteDamageInfo.GetDamageInfo(EffectDuration.FullRound).Damage;
        if (!roundInfo.UnitAttacksCount.HasUnitAttacked(Attacker))
            newDamage += absoluteDamageInfo.GetDamageInfo(EffectDuration.FirstAttack).Damage;
        if (roundInfo.AttackType is AttackType.FollowUpAttack)
            newDamage += absoluteDamageInfo.GetDamageInfo(EffectDuration.FollowUp).Damage;
        newDamage = Math.Round(newDamage,9);
        return Convert.ToInt32(Math.Floor(newDamage));
    }
}