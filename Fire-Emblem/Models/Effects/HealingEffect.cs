using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class HealingEffect: Effect
{
    private double _percentageToHeal;

    public HealingEffect(Unit unit, double percentageToHeal)
    {
        Unit = unit;
        _percentageToHeal = percentageToHeal;
    }
    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.HealingEffectActive.Active = true;
        effectsSummary.HealingEffectActive.Percentage += _percentageToHeal;

    }

    public override void RevertEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.HealingEffectActive.Active = false;
    }

    public override int GetPriority() => 1;
}