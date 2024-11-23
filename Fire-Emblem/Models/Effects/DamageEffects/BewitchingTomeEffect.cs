using System.Runtime.InteropServices.ComTypes;
using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Conditions;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;

namespace Fire_Emblem.Effects.DamageEffects;

public class BewitchingTomeEffect: DamageEffect
{
    
    private Unit _rival;
    private double _percentage;

    public BewitchingTomeEffect(Unit unit, Unit rival, EffectDuration effectDuration)
    {

        Unit = unit;
        _rival = rival;
        _percentage = 0.2;
        EffectDuration = effectDuration;

    }
    
    public override void ApplyEffect()
    {
        CalculatePercentage();
        Effect effect = new BeforeCombatDamageEffect(_rival, -Convert.ToInt32(Math.Floor(_percentage * _rival.Stats.GetAtk()))
            );
        effect.ApplyEffect();

    }

    private void CalculatePercentage()
    {
        AdvantageManager advantageManager = new AdvantageManager(Unit, _rival);

        if (Unit.Stats.GetSpd() > _rival.Stats.GetSpd())
            _percentage = 0.4;

        try
        {
            if (Unit == advantageManager.GetUnitWithAdvantage())
                _percentage = 0.4;
        }
        catch (NoUnitWithAdvantage){}
    }
    
    

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    
}