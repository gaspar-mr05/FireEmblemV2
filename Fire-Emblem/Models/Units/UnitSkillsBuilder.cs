
using Fire_Emblem.Combat;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Skills;

namespace Fire_Emblem.Models.Units;

public class UnitSkillsBuilder
{
    private RoundInfo _roundInfo;

    public UnitSkillsBuilder(RoundInfo roundInfo)
    {
        _roundInfo = roundInfo;
        
    }

    public SkillsCollection BuildSkills(Unit attacker, Unit defender)
    {
        SkillsCollection skillsCollection = new SkillsCollection();
        foreach (string skillName in attacker.SkillsNames)
        {
            SkillBuilder skillBuilder = new SkillBuilder(_roundInfo, skillName);
            skillsCollection.AddSkill(skillBuilder.BuildSkill(attacker, defender));
        }
        return skillsCollection;
    }
}