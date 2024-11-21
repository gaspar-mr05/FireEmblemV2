using Fire_Emblem.Characters;
using Fire_Emblem.Combat;
using Fire_Emblem.Models;

namespace Fire_Emblem.Conditions;

public class UnitUseWeaponType: ICondition
{
    private Weapons _weapons;
    private Unit _unit;

    public UnitUseWeaponType(Unit unit,  Weapons weapons)
    {
        _unit = unit;
        _weapons = weapons;
    }
    public bool IsConditionMet()
    {
        string unitWeapon = _unit.CharacterInfo.Weapon;
        return _weapons.ContainsWeapon(unitWeapon);

    }
}