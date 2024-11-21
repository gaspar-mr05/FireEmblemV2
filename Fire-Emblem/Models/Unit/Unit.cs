using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Unit;

namespace Fire_Emblem.Characters;

public class Unit
{

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


    public bool IsAlive()
    {
        return Stats.GetHp() > 0;
    }

}