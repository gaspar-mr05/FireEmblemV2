using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Combat;

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