using Fire_Emblem.Combat;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class AttackEffectsApplier
{
    private Unit _attacker;
    private Unit _defender;

    public AttackEffectsApplier(Unit attacker, Unit defender)
    {
        _attacker = attacker;
        _defender = defender;
    }

    public double ApplyAttackEffects(double damage, RoundInfo roundInfo, double wtb)
    {
        AttackEffectsManagerBuilder attackEffectsManagerBuilder = new AttackEffectsManagerBuilder(  _attacker,
        _defender, roundInfo);
        AttackEffectsManager attackEffectsManager = attackEffectsManagerBuilder.BuildAttackEffectsManager();
        AttacksEffectsInfo attacksEffectsInfo = attackEffectsManager.GetAttackEffects();
        double newDamage = damage + ((attacksEffectsInfo.AtkEffect * wtb) - attacksEffectsInfo.DefEffect);
        if (_attacker.CharacterInfo.Weapon == "Magic")
        {
            newDamage = damage + ((attacksEffectsInfo.AtkEffect * wtb) - attacksEffectsInfo.ResEffect);
        }


        return newDamage;
    }
}