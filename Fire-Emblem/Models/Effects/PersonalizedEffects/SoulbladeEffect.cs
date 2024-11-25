using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class SoulbladeEffect: NormalEffect
{
    private Effect _effect;
    private Unit _rival;


    public SoulbladeEffect(Unit rival, string statName)
    {
        base.StatName = statName;
        _rival = rival;
    }
    public override void ApplyEffect()
    {
        CalculateChange();
        if (Change >= 0)
            _effect = new BonusEffect(_rival, StatName, Change);
        else if (Change < 0)
            _effect = new PenaltyEffect(_rival, StatName, -1 * Change);
        _effect.ApplyEffect();

    }

    public override void RevertEffect()
    {
        _effect.RevertEffect();
    }

    private void CalculateChange()
    {
        int averageRivalDefRes = (Convert.ToInt32(_rival.CharacterInfo.Def) + 
        Convert.ToInt32(_rival.CharacterInfo.Res)) / 2;
        base.Change = averageRivalDefRes - Convert.ToInt32(_rival.CharacterInfo.GetInfoByName(StatName));
    }
    
}