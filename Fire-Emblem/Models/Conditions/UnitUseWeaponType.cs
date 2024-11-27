using Fire_Emblem.Models.Advantage;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

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