using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class BonusNeutralizationEffect : NeutralizationEffect
{
    public BonusNeutralizationEffect(Unit unit, string statName): base(unit, statName)
    {
    }
    

    protected override void NeutralizeEffect(ActiveEffectsInfo activeEffectsInfo)
    {
        EffectsCollection activeBonusEffectsCopy = activeEffectsInfo.BonusEffects;
        activeBonusEffectsCopy.RevertStatEffects(StatName);
        
    }

    protected override void RegisterEffect()
    {

        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.BonusNeutralizationEffectInfo.SetActiveTrue(StatName);
    }
    
    
    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }
}
