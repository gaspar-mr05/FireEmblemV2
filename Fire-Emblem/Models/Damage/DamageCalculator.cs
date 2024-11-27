using Fire_Emblem.Combat;
using Fire_Emblem.Models.Advantage;
using Fire_Emblem.Models.Attacks;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class DamageCalculator
{
    private Unit _attacker;
    private Unit _defender;
    private RoundInfo _roundInfo;


    public DamageCalculator(Unit attacker, Unit defender, RoundInfo roundInfo)
    {
        _attacker = attacker;
        _defender = defender;
        _roundInfo = roundInfo;
        

    }

    public double CalculateDamage()
    {
        AdvantageManager advantageManager = new AdvantageManager(_attacker, _defender);
        double wtb = advantageManager.CalculateWtbWithAdvantage();
        double damage = _attacker.Stats.GetAtk() * wtb -
                        _defender.Stats.GetDef();
        if (_attacker.CharacterInfo.Weapon == "Magic")
            damage = _attacker.Stats.GetAtk() * wtb - _defender.Stats.GetRes();
        AttackEffectsApplier attackEffectsApplier = new AttackEffectsApplier(_attacker, _defender);
        return attackEffectsApplier.ApplyAttackEffects(damage, _roundInfo, wtb);
        
    }

    public int GetDamageWithEffects()
    {
        DamageEffectsApplier damageEffectsApplier = new DamageEffectsApplier(_attacker, _defender);
        double damage = Math.Max(CalculateDamage(), 0);
        damage = Math.Max((damageEffectsApplier.ApplyDamageEffects(damage, _roundInfo)), 0);
        int newDamage = Convert.ToInt32(Math.Floor(damage));
        return newDamage;
    }
    
    


}

  