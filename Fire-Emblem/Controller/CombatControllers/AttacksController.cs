using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Combat;
using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.ViewPrinter;


public class AttacksController
{
    private readonly Unit _attacker;
    private readonly Unit _defender;
    private readonly AttacksView _attacksView;
    private readonly FirstAttackExecutor _firstAttackExecutor;
    private readonly CounterAttackExecutor _counterAttackExecutor;
    private readonly FollowUpAttackExecutor _followUpAttackExecutor;

    public AttacksController(View view, Unit attacker, Unit defender, RoundInfo roundInfo)
    {
        _attacker = attacker;
        _defender = defender;
        _attacksView = new AttacksView(view, attacker, defender);
        _firstAttackExecutor = new FirstAttackExecutor(roundInfo);
        _counterAttackExecutor = new CounterAttackExecutor(roundInfo);
        _followUpAttackExecutor = new FollowUpAttackExecutor(roundInfo);
    }

    public void ExecuteAllAttacks(SkillsManager skillsManager)
    {
        string[] beforeCombatMessages = DamageOutOfCombatManager.ApplyDamageOutOfCombat(_attacker, _defender,
            EffectDuration.BeforeCombat);
        string[] attackMessages = ExecuteCombatAttacks(skillsManager);
        string[] afterCombatMessages = DamageOutOfCombatManager.ApplyDamageOutOfCombat(_attacker, _defender, EffectDuration.AfterCombat);

        string[][] allMessages = new []{beforeCombatMessages, attackMessages, afterCombatMessages};
        ProcessAttackMessages(allMessages);
        RegisterAttacks();
    }



    private string[] ExecuteCombatAttacks(SkillsManager skillsManager)
    {
        string firstAttackMessage = _firstAttackExecutor.ExecuteAttack(_attacker, _defender);
        string counterAttackMessage = _counterAttackExecutor.ExecuteAttack(_attacker, _defender);
        string followUpMessage = _followUpAttackExecutor.ExecuteAttack(_attacker, _defender);
        skillsManager.ActivateAfterCombatEffects();

        return new[] { firstAttackMessage, counterAttackMessage, followUpMessage };
    }
    
    

    private void ProcessAttackMessages(string[][] attackMessages)
    {
        _attacksView.ShowAttacksMessages(attackMessages);
    }

    private void RegisterAttacks()
    {
        _attacker.UnitRoundsInfo.LastRival = _defender;
        _defender.UnitRoundsInfo.LastRival = _attacker;
        _attacker.UnitRoundsInfo.AttackingRoundsCount += 1;
        _defender.UnitRoundsInfo.DefendingRoundsCount += 1;
    }
}
