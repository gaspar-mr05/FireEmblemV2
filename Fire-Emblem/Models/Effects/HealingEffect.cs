using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class HealingEffect: Effect
{
    private double _percentageToHeal;

    public HealingEffect(Unit unit, double percentageToHeal): base(unit)
    {
        _percentageToHeal = percentageToHeal;
    }
    public override void ApplyEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.ActiveHealingInfo.Active = true;
        effectsSummary.ActiveHealingInfo.Percentage += _percentageToHeal;

    }

    public override void RevertEffect()
    {
        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.ActiveHealingInfo.Active = false;
    }

    public override int GetPriority() => 1;
}