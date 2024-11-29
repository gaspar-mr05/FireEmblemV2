using Fire_Emblem_View;
using Fire_Emblem.Combat;
using Fire_Emblem.Models.Attacks;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Skills;
using Fire_Emblem.Models.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controller.CombatControllers;

public class AttacksController
{
    private readonly Unit _attacker;
    private readonly Unit _defender;
    private readonly View _view;
    private readonly FirstAttackExecutor _firstAttackExecutor;
    private readonly CounterAttackExecutor _counterAttackExecutor;
    private readonly FollowUpAttackExecutor _followUpAttackExecutor;

    public AttacksController(View view, Unit attacker, Unit defender, RoundInfo roundInfo)
    {
        _attacker = attacker;
        _defender = defender;
        _view = view;
        _firstAttackExecutor = new FirstAttackExecutor(roundInfo);
        _counterAttackExecutor = new CounterAttackExecutor(roundInfo);
        _followUpAttackExecutor = new FollowUpAttackExecutor(roundInfo);
    }

    public void ExecuteRoundAttacks(SkillsManager skillsManager)
    {
        ApplyOutOfCombatDamage(EffectDuration.BeforeCombat);
        ExecuteCombatAttacks();
        ActivateSkillsAfterCombat(skillsManager);
        ApplyOutOfCombatDamage(EffectDuration.AfterCombat);
        RegisterCombatInfo();
       
    }
    

    private void ExecuteCombatAttacks()
    {
        AttacksView attacksView = new AttacksView(_view);
        ExecuteFirstAttack(attacksView);
        ExecuteCounterAttack(attacksView);
        ExecuteFollowUpAttacks(attacksView);
    }

    private void ExecuteFirstAttack(AttacksView attacksView)
    {
        AttackInfo firstAttackInfo = _firstAttackExecutor.ExecuteAttack(_attacker, _defender);
        attacksView.ShowAttackMessage(firstAttackInfo);
    }

    private void ExecuteCounterAttack(AttacksView attacksView)
    {
        AttackInfo counterAttackInfo = _counterAttackExecutor.ExecuteAttack(_attacker, _defender);
        attacksView.ShowAttackMessage(counterAttackInfo);
    }

    private void ExecuteFollowUpAttacks(AttacksView attacksView)
    {
        (AttackInfo attackerFollowUpInfo, AttackInfo defenderFollowUpInfo) =
            _followUpAttackExecutor.ExecuteAttack(_attacker, _defender);
        attacksView.ShowFollowUpMessage(attackerFollowUpInfo, defenderFollowUpInfo);
    }

    private void ActivateSkillsAfterCombat(SkillsManager skillsManager)
    {
        skillsManager.ActivateAfterCombatEffects();
    }
    
    private void ApplyOutOfCombatDamage(EffectDuration effectDuration)
    {
        DamageOutOfCombatView damageOutOfCombatView = new DamageOutOfCombatView(_view);
        DamageOutOfCombatInfo[] damageOutOfCombatInfos = 
            DamageOutOfCombatManager.ApplyDamageOutOfCombat(_attacker, _defender, effectDuration);
        damageOutOfCombatView.ShowDamageOutOfCombatMessages(damageOutOfCombatInfos);
    }

    private void RegisterCombatInfo()
    {
        _attacker.UnitRoundsInfo.LastRival = _defender;
        _defender.UnitRoundsInfo.LastRival = _attacker;
        _attacker.UnitRoundsInfo.AttackingRoundsCount++;
        _defender.UnitRoundsInfo.DefendingRoundsCount++;
    }
    
}
