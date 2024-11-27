using Fire_Emblem.Conditions;

namespace Fire_Emblem.Models.Skills;

public class SkillsCollection
{
    private List<Skill> _skillsList = new();

    public void AddSkill(Skill skill)
        => _skillsList.Add(skill);

    public void ApplyEffects(int priority)
    {
        foreach (Skill skill in _skillsList)
        {
            skill.ApplyEffects(priority);
        }
    }

    
    
    
}