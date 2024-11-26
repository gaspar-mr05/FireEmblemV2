using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Effects.PersonalizedEffects;

namespace Fire_Emblem.Effects.DamageEffects;

public class AbsoluteDamageReductionBasedOnDifference: EffectBasedOnDifference
{
    



    public AbsoluteDamageReductionBasedOnDifference(Unit unit, Unit rival, string statName, double percentage, int max, 
        EffectDuration effectDuration): base(unit, rival, statName, percentage, max, effectDuration)
    {
        
    }

    public override void ApplyEffect()
    {
        int absoluteDamage = CalculateChange();
        AbsoluteDamageReduction absoluteDamageReduction = new AbsoluteDamageReduction(Unit, absoluteDamage, EffectDuration);
        absoluteDamageReduction.ApplyEffect();
    }
    

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}