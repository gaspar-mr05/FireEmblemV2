using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Attacks;

public class AttackInfo
{
    public Unit Attacker;
    public Unit Defender;
    public int Damage;
    public int HpHealed;
    public AttackError AttackError;

    public AttackInfo(Unit attacker, Unit defender, int damage, int hpHealed, AttackError attackError)
    {
        Attacker = attacker;
        Defender = defender;
        Damage = damage;
        HpHealed = hpHealed;
        AttackError = attackError;
    }
}