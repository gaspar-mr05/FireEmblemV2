using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Exceptions;

namespace Fire_Emblem.Effects.DamageEffects;

public class ExtraDamageBasedOnPercentage: DamageEffect
{
    
    private Unit _rival;
    private string _statName;
    private double _percentage;
    private BasedOn _basedOn;


    public ExtraDamageBasedOnPercentage(Unit unit, Unit rival, string statName, double percentage, EffectDuration effectDuration, 
        BasedOn basedOn): base(unit, effectDuration)
    {
        
        _rival = rival;
        _statName = statName;
        _percentage = percentage;
        _basedOn = basedOn;

    }

    public override void ApplyEffect()
    {
        int extraDamage = CalculateDamage();
        ExtraDamageEffect extraDamageEffect = new ExtraDamageEffect(Unit, extraDamage, EffectDuration);
        extraDamageEffect.ApplyEffect();
    }
    

    private int CalculateDamage()
    {
        if (_basedOn == BasedOn.Rival)
            return Convert.ToInt32(Math.Floor(_percentage * _rival.Stats.GetStat(_statName)));
        if (_basedOn == BasedOn.Unit)
            return Convert.ToInt32(Math.Floor(_percentage * Unit.Stats.GetStat(_statName)));
        throw new BasedOnException();
    }
    
    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    
}