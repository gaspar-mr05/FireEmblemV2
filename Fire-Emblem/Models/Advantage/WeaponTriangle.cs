namespace Fire_Emblem.Combat;

public class WeaponTriangle
{
    public Dictionary<string, string> WeaponTriangleDict;

    public WeaponTriangle()
    {
        WeaponTriangleDict = new Dictionary<string, string>()
        {
            { "Sword", "Axe" },
            { "Lance", "Sword" },
            { "Axe", "Lance" },
        };
    }

    public bool HasWeapon(string weapon)
    {
        return WeaponTriangleDict.ContainsKey(weapon);

    }
    
    public bool IsWeaponStronger(string weaponToAttack, string weaponToDefend)
    {
        return WeaponTriangleDict[weaponToAttack] == weaponToDefend;
    }

}