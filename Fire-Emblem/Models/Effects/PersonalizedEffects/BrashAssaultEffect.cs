using Fire_Emblem.Combat;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class BrashAssaultEffect: Effect
{
    private Unit _rival;
    private RoundInfo _roundInfo;

    public BrashAssaultEffect(Unit unit, Unit rival, RoundInfo roundInfo): base(unit)
    {
        _rival = rival;
        _roundInfo = roundInfo;
    }

    public override void ApplyEffect()
    {
        DamageCalculator damageCalculator = new DamageCalculator(_rival, Unit, _roundInfo);
        int damage = Convert.ToInt32(Math.Floor(damageCalculator.CalculateDamage()));
        int damageWithoutReduction = CalculateDamageWithoutReduction(damage);
        
        ExtraDamageEffect extraDamageEffect = new ExtraDamageEffect(Unit, 
            Convert.ToInt32(Math.Floor(0.3 * damageWithoutReduction)), EffectDuration.FollowUp);
        
        extraDamageEffect.ApplyEffect();
    }



    private int CalculateDamageWithoutReduction(int damage)
    {
        DamageEffectInfo rivalExtraDamageEffectInfo = _rival.EffectsSummary.ExtraDamageInfo;

        int extraDamage = rivalExtraDamageEffectInfo.GetDamageInfo(EffectDuration.FirstAttack).Damage + 
                          rivalExtraDamageEffectInfo.GetDamageInfo(EffectDuration.FullRound).Damage;
        return damage + extraDamage;
    }


    public override int GetPriority() => 6;

    
    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}