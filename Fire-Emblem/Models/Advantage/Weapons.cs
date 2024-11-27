namespace Fire_Emblem.Models.Advantage;

public class Weapons
{

    private List<string> _weapons = new();


    public void AddWeapons(string[] weapons)
    {
        for (int weaponIndex = 0; weaponIndex < weapons.Length; weaponIndex++)
        {
            _weapons.Add(weapons[weaponIndex]);
        }
    }
    


    
    public bool ContainsWeapon(string weapon){
    
        return _weapons.Contains(weapon);
    }
    


}