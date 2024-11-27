namespace Fire_Emblem.Models.Advantage;

public class WeaponTriangle
{
    private Dictionary<string, string> _weaponTriangleDict;

    public WeaponTriangle()
    {
        _weaponTriangleDict = new Dictionary<string, string>()
        {
            { "Sword", "Axe" },
            { "Lance", "Sword" },
            { "Axe", "Lance" },
        };
    }

    public bool HasWeapon(string weapon)
    {
        return _weaponTriangleDict.ContainsKey(weapon);

    }
    
    public bool IsWeaponStronger(string weaponToAttack, string weaponToDefend)
    {
        return _weaponTriangleDict[weaponToAttack] == weaponToDefend;
    }

}