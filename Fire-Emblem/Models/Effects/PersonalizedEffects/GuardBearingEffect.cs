using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class GuardBearingEffect: DamageEffect
{
    private RoundInfo _roundInfo;


    public GuardBearingEffect(Unit unit, EffectDuration effectDuration, RoundInfo roundInfo): base(unit, effectDuration)
    {
        _roundInfo = roundInfo;

    }

    public override void ApplyEffect()
    {
        PercentageDamageReductionEffect percentageDamageReductionEffect =
            new PercentageDamageReductionEffect(Unit, CalculatePercentage(), EffectDuration);
        percentageDamageReductionEffect.ApplyEffect();
    }



    private double CalculatePercentage()
    {
        UnitRoundsInfo unitRoundsInfo = Unit.UnitRoundsInfo;
        if (Unit == _roundInfo.Attacker && unitRoundsInfo.AttackingRoundsCount == 0)
            return 0.6;
        if (Unit == _roundInfo.Defender && unitRoundsInfo.DefendingRoundsCount == 0)
            return 0.6;
        return 0.3;
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}