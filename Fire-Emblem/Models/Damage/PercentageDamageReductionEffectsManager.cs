using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class PercentageDamageReductionEffectsManager: DamageEffectsManager
{
    public PercentageDamageReductionEffectsManager(Unit attacker, Unit defender)
    {

        base.Attacker = attacker;
        base.Defender = defender;
    }

    public override int ApplyDamageEffects(double damage, RoundInfo roundInfo)
    {
        PercentageDamageEffectInfo percentageDamageInfo =
            Defender.EffectsSummary.PercentageDamageReductionInfo;
        
        double newDamage = damage * (1 - percentageDamageInfo.GetPercentageReduction(EffectDuration.FullRound).Percentage);
        if (!roundInfo.UnitAttacksCount.HasUnitAttacked(Attacker))
            newDamage = newDamage * (1 - percentageDamageInfo.GetPercentageReduction(EffectDuration.FirstAttack).Percentage);
        if (roundInfo.AttackType is AttackType.FollowUpAttack)
            newDamage = newDamage * (1 - percentageDamageInfo.GetPercentageReduction(EffectDuration.FollowUp).Percentage);
        newDamage = Math.Round(newDamage,9);
        
        return  Convert.ToInt32(Math.Floor(newDamage));
    }
}