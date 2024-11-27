using Fire_Emblem.Effects;

namespace Fire_Emblem.Models.Units;

public class ActiveEffectsInfo
{
    public EffectsCollection BonusEffects;
    public EffectsCollection PenaltyEffects;



    public ActiveEffectsInfo()
    {
        BonusEffects = new EffectsCollection();
        PenaltyEffects = new EffectsCollection();

    }
    
}