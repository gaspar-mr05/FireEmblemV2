using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public abstract class EffectBasedOnDifference: Effect
{
    
    protected Characters.Unit Rival;
    protected string StatName;
    protected double Percentage;
    protected int Max;

    protected EffectBasedOnDifference(Characters.Unit unit, Characters.Unit rival, string statName, double percentage, int max)
    {

        base.Unit = unit;
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

    public override int GetPriority()
    {
        throw new NotImplementedException();
    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}