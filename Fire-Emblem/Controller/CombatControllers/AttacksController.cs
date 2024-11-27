using Fire_Emblem_View;
using Fire_Emblem.Combat;
using Fire_Emblem.Models.Attacks;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Skills;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Controller.CombatControllers;

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
        _attacksView = new AttacksView(view);
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

    private void ApplyOutOfCombatDamage(EffectDuration effectDuration)
    {
        DamageOutOfCombatInfo[] damageOutOfCombatInfos = 
            DamageOutOfCombatManager.ApplyDamageOutOfCombat(_attacker, _defender, effectDuration);
        _attacksView.ShowDamageOutOfCombatMessages(damageOutOfCombatInfos);
    }

    private void ExecuteCombatAttacks()
    {
        ExecuteFirstAttack();
        ExecuteCounterAttack();
        ExecuteFollowUpAttacks();
    }

    private void ExecuteFirstAttack()
    {
        AttackInfo firstAttackInfo = _firstAttackExecutor.ExecuteAttack(_attacker, _defender);
        _attacksView.ShowAttackMessage(firstAttackInfo);
    }

    private void ExecuteCounterAttack()
    {
        AttackInfo counterAttackInfo = _counterAttackExecutor.ExecuteAttack(_attacker, _defender);
        _attacksView.ShowAttackMessage(counterAttackInfo);
    }

    private void ExecuteFollowUpAttacks()
    {
        (AttackInfo attackerFollowUpInfo, AttackInfo defenderFollowUpInfo) =
            _followUpAttackExecutor.ExecuteAttack(_attacker, _defender);
        _attacksView.ShowFollowUpMessage(attackerFollowUpInfo, defenderFollowUpInfo);
    }

    private void ActivateSkillsAfterCombat(SkillsManager skillsManager)
    {
        skillsManager.ActivateAfterCombatEffects();
    }

    private void RegisterCombatInfo()
    {
        UpdateLastRival();
        UpdateRoundsCount();
    }

    private void UpdateLastRival()
    {
        _attacker.UnitRoundsInfo.LastRival = _defender;
        _defender.UnitRoundsInfo.LastRival = _attacker;
    }

    private void UpdateRoundsCount()
    {
        _attacker.UnitRoundsInfo.AttackingRoundsCount++;
        _defender.UnitRoundsInfo.DefendingRoundsCount++;
    }
}
