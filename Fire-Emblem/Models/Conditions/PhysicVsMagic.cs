using Fire_Emblem.Characters;
using Fire_Emblem.Combat;

namespace Fire_Emblem.Conditions;

public class PhysicVsMagic: ICondition
{
    private Unit _unit;
    private Unit _rival;

    public PhysicVsMagic(Unit unit, Unit rival)
    {
        _unit = unit;
        _rival = rival;
    }
    public bool IsConditionMet()
    {
        return HasSomeoneMagicWeapon();
    }

    private bool HasSomeoneMagicWeapon()
    {
        return ((_unit.CharacterInfo.Weapon != "Magic" && _rival.CharacterInfo.Weapon == "Magic") ||
                (_rival.CharacterInfo.Weapon != "Magic" && _unit.CharacterInfo.Weapon == "Magic"));



    }
}