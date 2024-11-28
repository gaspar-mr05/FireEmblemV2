using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public abstract class EffectBasedOnDifference: DamageEffect
{
    
    private Unit _rival;
    private double _percentage;
    private int _max;

    protected EffectBasedOnDifference(Unit unit, Unit rival, string statName, double percentage, 
        int max, EffectDuration effectDuration): base(unit, effectDuration)
    {
        
        _rival = rival;
        StatName = statName;
        _percentage = percentage;
        _max = max;
    }
    

    protected int CalculateChange()
    {
        int statDifference = Unit.Stats.GetStat(StatName) - _rival.Stats.GetStat(StatName);
        int change = Math.Max(0, Math.Min(Convert.ToInt32(Math.Floor
            (_percentage * statDifference)), _max));
        return change;
    }

    

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}