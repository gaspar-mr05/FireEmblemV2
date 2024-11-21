using Fire_Emblem.Characters;

namespace Fire_Emblem.Combat;

public class AttackMessageGenerator
{
    private Unit _attacker;
    private Unit _defender;
    private int _damage;

    public AttackMessageGenerator(Unit attacker, Unit defender, int damage)
    {
        _attacker = attacker;
        _defender = defender;
        _damage = damage;
    }

    public string GenerateAttackMessage()
    {
        return $"{_attacker.CharacterInfo.Name} ataca a {_defender.CharacterInfo.Name} con {_damage} de daño";
    }
}