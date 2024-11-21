using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.DamageEffects;

public class StatDifferenceDamageReduction: DamageEffect
{
    private Unit _rival;
    private string _statName;
    private double _percentage;

    public StatDifferenceDamageReduction(Unit unit, Unit rival, string statName, EffectDuration effectDuration)
    {
        base.Unit = unit;
        base.EffectDuration = effectDuration;
        _rival = rival;
        _statName = statName;
    }

    public override void ApplyEffect()
    {


        CalculatePercentage();
        PercentageDamageReduction percentageDamageReduction = new PercentageDamageReduction(Unit, 
        _percentage, EffectDuration);
        percentageDamageReduction.ApplyEffect();


    }
    public void CalculatePercentage()
    {
        _percentage = Math.Min(0.4,
            (Unit.Stats.GetStat(_statName) - _rival.Stats.GetStat(_statName)) * 0.04);
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}