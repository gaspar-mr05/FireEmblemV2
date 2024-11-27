using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class DragonWrathEffect: DamageEffect
{
    private Unit _rival;
    private string _unitStatName;
    private string _rivalStatName;

    public DragonWrathEffect(Unit unit, Unit rival, string unitStatName, string rivalStatName, 
    EffectDuration effectDuration): base(unit, effectDuration)
    {
        _rival = rival;
        _unitStatName = unitStatName;
        _rivalStatName = rivalStatName;

    }

    public override void ApplyEffect()
    {
        ExtraDamageEffect extraDamageEffect = new ExtraDamageEffect(Unit, CalculateChange(), EffectDuration);
        extraDamageEffect.ApplyEffect();
    }
    
    private int CalculateChange()
    {
        return Convert.ToInt32(Math.Floor(0.25 * (Unit.Stats.GetStat(_unitStatName) - _rival.Stats.GetStat(_rivalStatName))));

    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
    
}