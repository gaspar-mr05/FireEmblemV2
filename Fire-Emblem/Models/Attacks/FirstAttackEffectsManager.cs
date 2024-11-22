using System.Runtime.InteropServices.Marshalling;
using Fire_Emblem.Characters;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.Combat;

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