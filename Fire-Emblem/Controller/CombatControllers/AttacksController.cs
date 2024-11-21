namespace Fire_Emblem.Combat;
using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.ViewPrinter;


public class AttacksController
{
    private Unit _attacker;
    private Unit _defender;
    private AttacksView _attacksView;
    private FirstAttackExecutor _firstAttackExecutor;
    private CounterAttackExecutor _counterAttackExecutor;
    private FollowUpAttackExecutor _followUpAttackExecutor;
    private SkillsManager _skillsManager;
    
    public AttacksController(View view, Unit attacker, Unit defender, RoundInfo roundInfo)
    {
        
        _attacker = attacker;
        _defender = defender;
        _attacksView = new AttacksView(view, attacker, defender);
        _firstAttackExecutor = new FirstAttackExecutor(roundInfo);
        _counterAttackExecutor = new CounterAttackExecutor(roundInfo);
        _followUpAttackExecutor = new FollowUpAttackExecutor(roundInfo);
        _skillsManager = new SkillsManager(roundInfo);

    }
    
    public void ExecuteAllAttacks()
    {

        _skillsManager.ActivateSkills();
        string firstAttackMessage = _firstAttackExecutor.ExecuteAttack(_attacker, _defender);
        string counterAttackMessage = _counterAttackExecutor.ExecuteAttack(_attacker, _defender);
        string followUpMessage = _followUpAttackExecutor.ExecuteAttack(_attacker, _defender);
        ProcessAttackMessages(firstAttackMessage, counterAttackMessage, followUpMessage);
        RegisterAttacks();
        _skillsManager.DeactivateSkills();

    }

 

    private void ProcessAttackMessages(string firstAttackMessage, string counterAttackMessage, string followUpMessage)
    {
        
        List<string> attackMessages = new List<string>{firstAttackMessage, counterAttackMessage, followUpMessage};
        
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
