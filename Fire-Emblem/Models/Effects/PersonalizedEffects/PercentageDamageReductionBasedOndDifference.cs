using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.DamageEffects;

public class PercentageDamageReductionBasedOndDifference: DamageEffect
{
    private Unit _rival;
    private string _statName;
    private double _percentage;
    private double _multiplier;

    public PercentageDamageReductionBasedOndDifference(Unit unit, Unit rival, string statName, 
        EffectDuration effectDuration, double multiplier): base(unit, effectDuration)
    {
        _rival = rival;
        _statName = statName;
        _multiplier = multiplier;
    }

    public override void ApplyEffect()
    {


        CalculatePercentage();
        PercentageDamageReduction percentageDamageReduction = new PercentageDamageReduction(Unit, 
        _percentage, EffectDuration);
        percentageDamageReduction.ApplyEffect();


    }
    private void CalculatePercentage()
    {
        _percentage = Math.Min(_multiplier/10,
            (Unit.Stats.GetStat(_statName) - _rival.Stats.GetStat(_statName)) * _multiplier/100);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}