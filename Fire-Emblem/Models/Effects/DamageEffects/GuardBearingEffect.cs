using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.DamageEffects;

public class GuardBearingEffect: DamageEffect
{
    private RoundInfo _roundInfo;


    public GuardBearingEffect(Unit unit, EffectDuration effectDuration, RoundInfo roundInfo)
    {
        base.Unit = unit;
        base.EffectDuration = effectDuration;
        _roundInfo = roundInfo;

    }

    public override void ApplyEffect()
    {
        PercentageDamageReduction percentageDamageReduction =
            new PercentageDamageReduction(Unit, CalculatePercentage(), EffectDuration);
        percentageDamageReduction.ApplyEffect();
    }



    private double CalculatePercentage()
    {
        UnitRoundsInfo unitRoundsInfo = Unit.UnitRoundsInfo;
        if (Unit == _roundInfo.UnitWhoStart && unitRoundsInfo.AttackingRoundsCount == 0)
            return 0.6;
        if (Unit == _roundInfo.UnitWhoNotStart && unitRoundsInfo.DefendingRoundsCount == 0)
            return 0.6;
        return 0.3;
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}