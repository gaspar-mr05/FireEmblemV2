using Fire_Emblem.Combat;
using Fire_Emblem.Models.Exceptions;
using Fire_Emblem.Models.Units;


namespace Fire_Emblem.Models.Advantage;

public class AdvantageManager
{
    private WeaponTriangle _weaponTriangle;
    private Unit _attacker;
    private Unit _defender;

    public AdvantageManager(Unit attacker, Unit defender)
    {
        _weaponTriangle = new WeaponTriangle();
        _attacker = attacker;
        _defender = defender;
    }
    
    public double CalculateWtbWithAdvantage()
    {
        double maxWtb = 1.2;
        double neutralWtb = 1;
        double minWtb = 0.8;
        
        string weaponToAttack = _attacker.CharacterInfo.Weapon;
        string weaponToDefend = _defender.CharacterInfo.Weapon;
        if (!IsAdvantagePresent())
            return neutralWtb;
        return  _weaponTriangle.IsWeaponStronger(weaponToAttack, weaponToDefend)? maxWtb : minWtb;
    }
    
    public Unit GetUnitWithAdvantage()
    {
        string weaponToAttack = _attacker.CharacterInfo.Weapon;
        string weaponToDefend = _defender.CharacterInfo.Weapon;

        if (!IsAdvantagePresent())
            throw new NoUnitWithAdvantage();
        
        if (_weaponTriangle.IsWeaponStronger(weaponToAttack, weaponToDefend))
            return _attacker;
        
        return _defender;
    }

    private bool IsAdvantagePresent()
    {
        string weaponToAttack = _attacker.CharacterInfo.Weapon;
        string weaponToDefend = _defender.CharacterInfo.Weapon;
        return _weaponTriangle.HasWeapon(weaponToAttack) && _weaponTriangle.HasWeapon(weaponToDefend)
                                                         && weaponToAttack != weaponToDefend;
    } 
    

    
}