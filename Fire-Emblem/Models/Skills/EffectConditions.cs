using Fire_Emblem.Effects;
using Fire_Emblem.Models.Conditions;
using Fire_Emblem.Models.Effects;

namespace Fire_Emblem.Models.Skills;

public class EffectConditions
{
    private Effect _effect;
    private ConditionsCollection _conditions;

    public EffectConditions(Effect effect, ConditionsCollection conditions)
    {
        _effect = effect;
        _conditions = conditions;
    }

    public void ApplyEffect()
    {
        if (_conditions.AreConditionsMet())
        {
            _effect.ApplyEffect();
        }
        
    }

    public int GetEffectPriority()
    {
        return _effect.GetPriority();
    }
}