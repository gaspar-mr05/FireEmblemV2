using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.NormalEffects;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Effects.PersonalizedEffects;

public class SoulbladeEffect: Effect
{
    private Effect _effect;
    private int _change;


    public SoulbladeEffect(Unit unit, string statName) : base(unit)
    {
        StatName = statName;
    }
    public override void ApplyEffect()
    {
        CalculateChange();
        if (_change >= 0)
            _effect = new BonusEffect(Unit, StatName, _change);
        else if (_change < 0)
            _effect = new PenaltyEffect(Unit, StatName, -1 * _change);
        _effect.ApplyEffect();

    }

    public override void RevertEffect()
    {
        _effect.RevertEffect();
    }

    private void CalculateChange()
    {
        int averageRivalDefRes = (Convert.ToInt32(Unit.CharacterInfo.Def) + 
        Convert.ToInt32(Unit.CharacterInfo.Res)) / 2;
        _change = averageRivalDefRes - Convert.ToInt32(Unit.CharacterInfo.GetInfoByName(StatName));
    }

    public override int GetPriority() => 1;
}