using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class PenaltyNeutralizationEffect: NeutralizationEffect
{
    public PenaltyNeutralizationEffect(Unit unit, string statName): base(unit, statName)
    {
    }

    
    protected override void NeutralizeEffect(ActiveEffectsInfo activeEffectsInfo)
    {
        EffectsCollection activePenaltyEffectsCopy = activeEffectsInfo.PenaltyEffects;
        activePenaltyEffectsCopy.RevertStatEffects(StatName);
        
    }

    protected override void RegisterEffect()
    {

        EffectsSummary effectsSummary = Unit.EffectsSummary;
        effectsSummary.PenaltyNeutralizationEffectInfo.SetActiveTrue(StatName);
    }
    
    public override void RevertEffect()
    {
        throw new NotImplementedException();
    }

}