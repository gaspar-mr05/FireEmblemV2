using Fire_Emblem_GUI;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;


namespace Fire_Emblem.Models.Units;

using Teams;

using System.Collections.Generic;

public class Unit : IUnit
{
    public Team Team;
    public CharacterInfo CharacterInfo;
    public Stats Stats;
    public string[] SkillsNames;
    public UnitRoundsInfo UnitRoundsInfo;
    public ActiveEffectsInfo ActiveEffectsInfo;
    public EffectsSummary EffectsSummary;

    public Unit(CharacterInfo characterInfo, Stats stats, string[] skillsNames)
    {
        CharacterInfo = characterInfo;
        Stats = stats;
        UnitRoundsInfo = new UnitRoundsInfo();
        SkillsNames = skillsNames;
        ActiveEffectsInfo = new ActiveEffectsInfo();
    }

    // Propiedades de la interfaz IUnit
    public string Name => CharacterInfo.Name;

    public string Weapon => CharacterInfo.Weapon;

    public int Hp => Stats.GetHp();

    public int Atk => Stats.GetAtk();

    public int Spd => Stats.GetSpd();

    public int Def => Stats.GetDef();

    public int Res => Stats.GetRes();

    public string[] Skills => SkillsNames;
    
    public bool HasUniqueSkills()
    {
        List<string> uniqueSkills = new List<string>();
        foreach (string skillName in SkillsNames)
        {
            if (uniqueSkills.Contains(skillName))
                return false;
            uniqueSkills.Add(skillName);
        }
        return true;
    }

    public bool IsAlive() => Stats.GetHp() > 0;
}

