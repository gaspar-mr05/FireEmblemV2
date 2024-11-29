using Fire_Emblem.Models.Advantage;
using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Effects.OutOfCombatDamageEffects;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Exceptions;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class BewitchingTomeEffect: DamageEffect
{
    
    private Unit _rival;
    private double _percentage;

    public BewitchingTomeEffect(Unit unit, Unit rival, EffectDuration effectDuration): base(unit, effectDuration)
    {
        _rival = rival;
        _percentage = 0.2;
    }
    
    public override void ApplyEffect()
    {
        CalculatePercentage();
        Effect effect = new BeforeCombatDamageEffect(_rival, -Convert.ToInt32(Math.Floor(_percentage * 
            _rival.Stats.GetAtk())));
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