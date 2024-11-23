using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;

namespace Fire_Emblem.Effects.DamageEffects;

public class MasterMindEffect: DamageEffect
{
    private Unit _rival;
    private int _damage;

    public MasterMindEffect(Unit unit, Unit rival, EffectDuration effectDuration)
    {

        Unit = unit;
        _rival = rival;
        EffectDuration = effectDuration;

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
        Console.WriteLine($"unitbonuses : {unitBonuses}");
        _damage = (int)Math.Truncate(0.8 * unitBonuses) + (int)Math.Truncate(0.8 * rivalPenalties);

    }

    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}