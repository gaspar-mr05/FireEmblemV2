using Fire_Emblem.Models.Unit;

namespace Fire_Emblem.Characters;
using System.Reflection;

public class UnitBuilder
{
    public static Unit BuildUnit(CharacterInfo characterInfo, string[] skillsNamesArray)
    {
        Stats stats  = new Stats(characterInfo);
        Unit unit = new Unit(characterInfo, stats, skillsNamesArray);
        SetBaseStatAlteration(unit);
        return unit;

    }



    

    private static void SetBaseStatAlteration(Unit unit)
    {
        string baseStatAlteration = "HP +15";
        if (unit.SkillsNames.Contains(baseStatAlteration)){
            unit.Stats.AddChange("HP", 15);
        }

    }



}