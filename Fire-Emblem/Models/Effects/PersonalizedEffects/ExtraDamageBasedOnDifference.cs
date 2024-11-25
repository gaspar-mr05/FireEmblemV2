using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Models.Effects.PersonalizedEffects;

namespace Fire_Emblem.Effects.DamageEffects;

public class ExtraDamageBasedOnDifference: EffectBasedOnDifference
{



    private EffectDuration _effectDuration;



    public ExtraDamageBasedOnDifference(Unit unit, Unit rival, string statName, double percentage, int max, 
        EffectDuration effectDuration): base(unit, rival, statName, percentage, max)
    {

        base.Unit = unit;
        _effectDuration = effectDuration;
        base.Rival = rival;
        base.StatName = statName;
        base.Percentage = percentage;
        base.Max = max;
    }

    public override void ApplyEffect()
    {
        int extraDamage = CalculateChange();
        ExtraDamageEffect extraDamageEffect = new ExtraDamageEffect(Unit, extraDamage, _effectDuration);
        extraDamageEffect.ApplyEffect();
    }

    public override int GetPriority() => 3;


    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}