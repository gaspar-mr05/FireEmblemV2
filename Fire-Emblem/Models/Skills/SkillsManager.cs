using System.Threading.Tasks.Sources;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Units;


namespace Fire_Emblem.Models.Skills;



public class SkillsManager
{
    private RoundInfo _roundInfo;
    private SkillsCollection _attackerSkillsCollection;
    private SkillsCollection _defenderSkillsCollection;

    public SkillsManager(RoundInfo roundInfo)
    {
        _roundInfo = roundInfo;
        UnitSkillsBuilder unitSkillsBuilder = new UnitSkillsBuilder(roundInfo);
        _attackerSkillsCollection = unitSkillsBuilder.BuildSkills(_roundInfo.Attacker, _roundInfo.Defender);
        _defenderSkillsCollection = unitSkillsBuilder.BuildSkills(_roundInfo.Defender, _roundInfo.Attacker);

    }

    public void ActivateEffects()
    {
        int maxPriority = 7;
        for (int priority = 1; priority <= maxPriority; priority++)
        {
            _defenderSkillsCollection.ApplyEffects(priority);
            _attackerSkillsCollection.ApplyEffects(priority);
            
        }
    }
    
    public void DeactivateEffects()
    {
        RevertEffects(_roundInfo.Attacker);
        RevertEffects(_roundInfo.Defender);
    }

    private void RevertEffects(Unit unit)
    {
        EffectsCollection bonusEffects = unit.ActiveEffectsInfo.BonusEffects;
        EffectsCollection penaltyEffects = unit.ActiveEffectsInfo.PenaltyEffects;
        bonusEffects.RevertEffects();
        penaltyEffects.RevertEffects();
    }

    public void ActivateAfterCombatEffects()
    {
        int afterCombatPriority = 8;
        _defenderSkillsCollection.ApplyEffects(afterCombatPriority);
        _attackerSkillsCollection.ApplyEffects(afterCombatPriority);
        

    }


    

}
