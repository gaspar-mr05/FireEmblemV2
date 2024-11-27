using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class ExtraDamageBasedOnDifference: EffectBasedOnDifference
{


    



    public ExtraDamageBasedOnDifference(Unit unit, Unit rival, string statName, double percentage, int max, 
        EffectDuration effectDuration): base(unit, rival, statName, percentage, max, effectDuration)
    { }

    public override void ApplyEffect()
    {
        int extraDamage = CalculateChange();
        ExtraDamageEffect extraDamageEffect = new ExtraDamageEffect(Unit, extraDamage, EffectDuration);
        extraDamageEffect.ApplyEffect();
    }
    


    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}