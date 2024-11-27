using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class ExtraDamageEffectsManager: DamageEffectsManager
{

    public ExtraDamageEffectsManager(Unit attacker, Unit defender)
    {
        base.Attacker = attacker;
        base.Defender = defender;

    }

    public override int ApplyDamageEffects(double damage, RoundInfo roundInfo)
    {
        DamageEffectInfo attackerExtraDamageInfo =
            Attacker.EffectsSummary.ExtraDamageInfo;
        
        double newDamage = damage + attackerExtraDamageInfo.GetDamageInfo(EffectDuration.FullRound).Damage;
        if (!roundInfo.UnitAttacksCount.HasUnitAttacked(Attacker))
            newDamage += attackerExtraDamageInfo.GetDamageInfo(EffectDuration.FirstAttack).Damage;
        if (roundInfo.AttackType is AttackType.FollowUpAttack)
            newDamage += attackerExtraDamageInfo.GetDamageInfo(EffectDuration.FollowUp).Damage;
        newDamage = Math.Round(newDamage,9);
        return Convert.ToInt32(Math.Floor(newDamage));
    }
}