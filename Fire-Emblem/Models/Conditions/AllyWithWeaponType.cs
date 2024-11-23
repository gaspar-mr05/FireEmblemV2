using Fire_Emblem.Characters;
using Fire_Emblem.Models;

namespace Fire_Emblem.Conditions;

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
        for (int index = 0; index < teamArray.Length; index++)
        {
            if (teamArray[index] != _unit)
                if (_weapons.ContainsWeapon(teamArray[index].CharacterInfo.Weapon))
                    return true;
        }
        return false;
    }
}