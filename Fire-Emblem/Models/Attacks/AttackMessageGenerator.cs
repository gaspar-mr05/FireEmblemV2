using Fire_Emblem.Characters;

namespace Fire_Emblem.Combat;

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
        string healingMessage;
        string damageMessage = $"{_attacker.CharacterInfo.Name} ataca a {_defender.CharacterInfo.Name} con {_damage} de daño" ;
        if (_hpHealed > 0)
        {
            healingMessage = $"{_attacker.CharacterInfo.Name} recupera {_hpHealed} de HP luego de atacar y queda con" +
                             $"{_attacker.Stats.GetHp()} HP";
            return healingMessage + "\n" + damageMessage;
            
        }
        return damageMessage;

    }
}