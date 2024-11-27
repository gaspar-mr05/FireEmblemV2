using System.Text.Unicode;
using Fire_Emblem_View;
using Fire_Emblem.Combat;
using Fire_Emblem.Models.Skills;

namespace Fire_Emblem.Models.Skills;

using Fire_Emblem.Effects;


public class Skill
{
    private EffectsConditionsCollection _effects;

    

    public Skill(EffectsConditionsCollection effects)
    {
        _effects = effects;
    }

    public void ApplyEffects(int priority)
    {
        _effects.ApplyEffects(priority);
    }


}
    

