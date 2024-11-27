using Fire_Emblem.Effects;
using Fire_Emblem.Models.Conditions;
using Fire_Emblem.Models.Effects;

namespace Fire_Emblem.Models.Skills;

public class EffectsConditionsCollection
{
    private List<EffectConditions> _effectConditionsList = new();

    public void AddEffectConditions(Effect effect, ConditionsCollection conditionsCollection)
        => _effectConditionsList.Add(new EffectConditions(effect, conditionsCollection));

    public void ApplyEffects(int priority)
    {
        foreach (EffectConditions effectConditions in _effectConditionsList)
        {
            if (effectConditions.GetEffectPriority() == priority)
                effectConditions.ApplyEffect();
        }
    }
}