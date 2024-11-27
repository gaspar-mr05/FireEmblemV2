using Fire_Emblem.Conditions;
using Fire_Emblem.Models.Effects.DamageEffects;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class MasterMindEffect: DamageEffect
{
    private Unit _rival;
    private int _damage;

    public MasterMindEffect(Unit unit, Unit rival, EffectDuration effectDuration): base(unit, effectDuration)
    {
        _rival = rival;
    }
    
    public override void ApplyEffect()
    {
        CalculateExtraDamage();
        Effect effect = new ExtraDamageEffect(Unit, _damage, EffectDuration);
        effect.ApplyEffect();

    }

    private void CalculateExtraDamage()
    {
        int unitBonuses = Unit.EffectsSummary.BonusesInfo.GetAllEffects();
        int rivalPenalties = _rival.EffectsSummary.PenaltiesInfo.GetAllEffects();
        _damage = (int)Math.Truncate(0.8 * unitBonuses) + (int)Math.Truncate(0.8 * rivalPenalties);

    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}