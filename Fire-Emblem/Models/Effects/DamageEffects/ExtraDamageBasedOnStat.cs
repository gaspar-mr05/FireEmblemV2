using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.DamageEffects;

public class ExtraDamageBasedOnStat: DamageEffect
{
    
    private Unit _rival;
    private string _statName;
    private double _percentage;


    public ExtraDamageBasedOnStat(Unit unit, Unit rival, string statName, double percentage, EffectDuration effectDuration)
    {

        base.Unit = unit;
        base.EffectDuration = effectDuration;
        _rival = rival;
        _statName = statName;
        _percentage = percentage;

    }

    public override void ApplyEffect()
    {
        int extraDamage = CalculateDamage();
        ExtraDamageEffect extraDamageEffect = new ExtraDamageEffect(Unit, extraDamage, EffectDuration);
        extraDamageEffect.ApplyEffect();
    }
    

    private int CalculateDamage()
    {
        return Convert.ToInt32(Math.Floor(_percentage * _rival.Stats.GetStat(_statName)));
    }
    
    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    
}