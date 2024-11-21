using Fire_Emblem.Characters;

namespace Fire_Emblem.Combat;

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
        AttacksEffects attacksEffects = attackEffectsManager.GetAttackEffects();
        double newDamage = damage + ((attacksEffects.AtkEffect * wtb) - attacksEffects.DefEffect);
        if (_attacker.CharacterInfo.Weapon == "Magic")
        {
            newDamage = damage + ((attacksEffects.AtkEffect * wtb) - attacksEffects.ResEffect);
        }


        return newDamage;
    }
}