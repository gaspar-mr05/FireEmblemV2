using System.Threading.Tasks.Sources;
using Fire_Emblem.Effects;
using Fire_Emblem.Skills;


namespace Fire_Emblem.Combat;
using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;


public class SkillsManager
{
    private RoundInfo _roundInfo;
    private SkillsCollection _attackerSkillsCollection;
    private SkillsCollection _defenderSkillsCollection;

    public SkillsManager(RoundInfo roundInfo)
    {
        _roundInfo = roundInfo;
        UnitSkillsBuilder unitSkillsBuilder = new UnitSkillsBuilder(roundInfo);
        _attackerSkillsCollection = unitSkillsBuilder.BuildSkills(_roundInfo.UnitWhoStart, _roundInfo.UnitWhoNotStart);
        _defenderSkillsCollection = unitSkillsBuilder.BuildSkills(_roundInfo.UnitWhoNotStart, _roundInfo.UnitWhoStart);

    }

    public void ActivateSkills()
    {
        int maxPriority = 6;
        for (int priority = 1; priority <= maxPriority; priority++)
        {
            _defenderSkillsCollection.ApplyEffects(priority);
            _attackerSkillsCollection.ApplyEffects(priority);
            
        }
    }
    
    public void DeactivateSkills()
    {
        RevertEffects(_roundInfo.UnitWhoStart);
        RevertEffects(_roundInfo.UnitWhoNotStart);
    }

    private void RevertEffects(Unit unit)
    {
        EffectsCollection bonusEffects = unit.ActiveEffectsInfo.BonusEffects;
        EffectsCollection penaltyEffects = unit.ActiveEffectsInfo.PenaltyEffects;
        bonusEffects.RevertEffects();
        penaltyEffects.RevertEffects();
    }


    

}
