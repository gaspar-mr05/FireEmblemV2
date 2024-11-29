using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class FollowUpEffectsManager: AttackEffectsManager
{

    public FollowUpEffectsManager(Unit attacker)
    {
        base.Attacker = attacker;

    }

    public override AttacksEffectsInfo GetAttackEffects()
    {
        NormalEffectInfo followUpAttackBonus = Attacker.EffectsSummary.FollowUpBonusesInfo;
        NormalEffectInfo followUpAttackPenalty = Attacker.EffectsSummary.FollowUpPenaltiesInfo;
        
        int atkEffect = followUpAttackBonus.GetEffectInfo("Atk").Active? 
            followUpAttackBonus.GetEffectInfo("Atk").Change : 0;
        
        atkEffect = followUpAttackPenalty.GetEffectInfo("Atk").Active ? 
            atkEffect + followUpAttackPenalty.GetEffectInfo("Atk").Change : atkEffect;
        
        
        return new AttacksEffectsInfo(atkEffect, 0 ,0);
        
    }
}