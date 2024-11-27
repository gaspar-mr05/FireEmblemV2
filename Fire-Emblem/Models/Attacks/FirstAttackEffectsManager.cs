using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class FirstAttackEffectsManager: AttackEffectsManager
{
    public FirstAttackEffectsManager(Unit attacker, Unit defender)
    {
        base.Attacker = attacker;
        base.Defender = defender;
    }

    public override AttacksEffects GetAttackEffects()
    {
        NormalEffectInfo attackerFirstAttackBonus = Attacker.EffectsSummary.FirstAttackBonusesInfo;
        NormalEffectInfo defenderFirstAttackPenalty = Defender.EffectsSummary.FirstAttackPenaltiesInfo;
        
        int atkEffect = attackerFirstAttackBonus.GetEffectInfo("Atk").Active? 
            attackerFirstAttackBonus.GetEffectInfo("Atk").Change : 0;
        
    int defEffect = defenderFirstAttackPenalty.GetEffectInfo("Def").Active? 
        defenderFirstAttackPenalty.GetEffectInfo("Def").Change : 0;
        
        int resEffect = defenderFirstAttackPenalty.GetEffectInfo("Res").Active ? 
            defenderFirstAttackPenalty.GetEffectInfo("Res").Change : 0;
        return new AttacksEffects(atkEffect, defEffect, resEffect);
    }
}