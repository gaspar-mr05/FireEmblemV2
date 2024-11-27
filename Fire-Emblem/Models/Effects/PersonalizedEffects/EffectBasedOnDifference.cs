using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public abstract class EffectBasedOnDifference: DamageEffect
{
    
    protected Unit Rival;
    protected string StatName;
    protected double Percentage;
    protected int Max;

    protected EffectBasedOnDifference(Unit unit, Unit rival, string statName, double percentage, 
        int max, EffectDuration effectDuration): base(unit, effectDuration)
    {
        
        Rival = rival;
        StatName = statName;
        Percentage = percentage;
        Max = max;
    }
    

    protected int CalculateChange()
    {
        int statDifference = Unit.Stats.GetStat(StatName) - Rival.Stats.GetStat(StatName);
        int change = Math.Max(0, Math.Min(Convert.ToInt32(Math.Floor
            (Percentage * statDifference)), Max));
        return change;
    }

    

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}