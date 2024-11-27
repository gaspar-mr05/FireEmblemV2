using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class AttackMessageGenerator
{
    private Unit _attacker;
    private Unit _defender;
    private int _damage;
    private int _hpHealed;

    public AttackMessageGenerator(Unit attacker, Unit defender, int damage, int hpHealed)
    {
        _attacker = attacker;
        _defender = defender;
        _damage = damage;
        _hpHealed = hpHealed;

    }

    public string GenerateAttackMessage()
    {
        string damageMessage = $"{_attacker.CharacterInfo.Name} ataca a {_defender.CharacterInfo.Name} con {_damage} de daño" ;
        if (_hpHealed > 0)
        {
            string healingMessage = $"{_attacker.CharacterInfo.Name} recupera {_hpHealed} HP luego de atacar y queda con" +
                             $" {_attacker.Stats.GetHp()} HP.";
            return damageMessage + "\n" + healingMessage;
            
        }
        return damageMessage;

    }
}