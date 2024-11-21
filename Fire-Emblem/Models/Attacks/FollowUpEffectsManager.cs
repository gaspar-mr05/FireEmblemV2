using Fire_Emblem.Characters;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Combat;

public class FollowUpEffectsManager: AttackEffectsManager
{

    public FollowUpEffectsManager(Unit attacker)
    {
        base.Attacker = attacker;

    }

    public override AttacksEffects GetAttackEffects()
    {
        NormalEffectInfo followUpAttackBonus = Attacker.EffectsSummary.FollowUpBonusEffectInfo;
        NormalEffectInfo followUpAttackPenalty = Attacker.EffectsSummary.FollowUpPenaltyEffectInfo;
        
        int atkEffect = followUpAttackBonus.GetEffectInfo("Atk").Active? 
            followUpAttackBonus.GetEffectInfo("Atk").Change : 0;
        
        atkEffect = followUpAttackPenalty.GetEffectInfo("Atk").Active ? 
            atkEffect + followUpAttackPenalty.GetEffectInfo("Atk").Change : atkEffect;
        
        
        return new AttacksEffects(atkEffect, 0 ,0);
        
    }
}