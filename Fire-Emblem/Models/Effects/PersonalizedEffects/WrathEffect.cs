using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class WrathEffect: NormalEffect
{
    private int _change;
    private Effect _bonusEffect;

    public WrathEffect(Unit unit, string statName)
    {
        base.Unit = unit;
        base.StatName = statName;
    }
    public override void ApplyEffect()
    {
        CalculateChange();
        _bonusEffect = new BonusEffect(Unit, StatName, _change);
        _bonusEffect.ApplyEffect();

    }

    private void CalculateChange()
    {
        int hpLost = Convert.ToInt32(Unit.CharacterInfo.HP) - Unit.Stats.GetHp();
        if (hpLost >= 30)
            _change = 30;
        else if (hpLost > 0)
            _change = hpLost;
    }

    public override void RevertEffect()
    {
        _bonusEffect.RevertEffect();
    }
    
}