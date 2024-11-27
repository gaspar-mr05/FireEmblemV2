using Fire_Emblem.Combat;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Damage;

public class DamageEffectsApplier
{

    private ExtraDamageEffectsManager _extraDamageEffectsManager;
    private AbsoluteDamageReductionEffectsManager _absoluteDamageReductionEffectsManager;
    private PercentageDamageReductionEffectsManager _percentageDamageReductionEffectsManager;

    public DamageEffectsApplier(Unit attacker, Unit defender)
    {

        _extraDamageEffectsManager = new ExtraDamageEffectsManager(attacker, defender);
        _absoluteDamageReductionEffectsManager = new AbsoluteDamageReductionEffectsManager(attacker, defender);
        _percentageDamageReductionEffectsManager = new PercentageDamageReductionEffectsManager(attacker, defender);
    }

    public int ApplyDamageEffects(double damage, RoundInfo roundInfo)
    {
        int newDamage = _extraDamageEffectsManager.ApplyDamageEffects(damage, roundInfo);
        newDamage = _percentageDamageReductionEffectsManager.ApplyDamageEffects(newDamage, roundInfo);
        newDamage = _absoluteDamageReductionEffectsManager.ApplyDamageEffects(newDamage, roundInfo);
        return newDamage;
    }
    

}