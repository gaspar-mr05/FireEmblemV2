using Fire_Emblem.Models.Advantage;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Models.Conditions;

public class AllyWithWeaponType: ICondition
{
    private Unit _unit;
    private Weapons _weapons;

    public AllyWithWeaponType(Unit unit, Weapons weapons)
    {
        _unit = unit;
        _weapons = weapons;
    }
    public bool IsConditionMet()
    {
        Unit[] teamArray = _unit.Team.GetTeam();
        foreach (var unit in teamArray)
        {
            if (unit != _unit)
                if (_weapons.ContainsWeapon(unit.CharacterInfo.Weapon))
                    return true;
        }
        return false;
    }
}