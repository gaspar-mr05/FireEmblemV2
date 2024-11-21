using Fire_Emblem_View;
using Fire_Emblem.Effects.DamageEffects;

namespace Fire_Emblem.Effects;

public class EffectsCollection
{
    private List<Effect> _effectsList = new();

    public void AddEffect(Effect effect)
        => _effectsList.Add(effect);


    public void RemoveEffect(Effect effect)
        => _effectsList.Remove(effect);


    
    public void RevertEffects()
    {
        List<Effect> effectsCopy = _effectsList.ToList();
        foreach (Effect effect in effectsCopy)
        {
            effect.RevertEffect();
        }
    }

    public void RevertStatEffects(string statName)
    {
        List<Effect> effectsCopy = _effectsList.ToList();
        foreach (Effect effect in effectsCopy)
        {
            if (effect.StatName == statName)
                effect.RevertEffect();
        }
        
    }
    
    
    

    
}