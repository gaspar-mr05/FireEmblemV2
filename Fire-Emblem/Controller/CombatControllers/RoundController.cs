using Fire_Emblem_View;
using Fire_Emblem.Combat;
using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Round;
using Fire_Emblem.Models.Skills;
using Fire_Emblem.Models.Teams;
using Fire_Emblem.Models.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controller.CombatControllers;

public class RoundController
{
    private readonly View _view;
    private int _roundNumber;
    private readonly UnitSelector _unitSelector;
    private readonly TurnsManager _turnsManager;
    private SkillsManager _skillsManager;

    public RoundController(View view)
    {
        _roundNumber = 1;
        _view = view;
        _unitSelector = new UnitSelector(_view);
        int playerWhoStarts = 1;
        _turnsManager = new TurnsManager(playerWhoStarts);
    }

    public void ExecuteRound(TeamsInfo teamsInfo)
    {
        (AttacksController attacksController, Unit attacker, Unit defender) = StartRound(teamsInfo);
        attacksController.ExecuteRoundAttacks(_skillsManager);
        EndRound(attacker, defender);
    }

    private (AttacksController, Unit, Unit) StartRound(TeamsInfo teamsInfo)
    {
        (Unit attacker, Unit defender) = SelectUnits(teamsInfo);
        InitializeEffects(attacker, defender);

        RoundInfo roundInfo = new RoundInfo(attacker, defender);
        _skillsManager = new SkillsManager(roundInfo);
        _skillsManager.ActivateEffects();

        ShowRoundStart(attacker, defender);
        ShowEffectsSummary(attacker, defender);

        AttacksController attacksController = new AttacksController(_view, attacker, defender, roundInfo);
        return (attacksController, attacker, defender);
    }

    private (Unit, Unit) SelectUnits(TeamsInfo teamsInfo)
    {
        return _unitSelector.SelectUnits(teamsInfo, _turnsManager.PlayerWhoStarts);
    }

    private void InitializeEffects(Unit attacker, Unit defender)
    {
        attacker.EffectsSummary = new EffectsSummary();
        defender.EffectsSummary = new EffectsSummary();
    }
    

    private void ShowRoundStart(Unit attacker, Unit defender)
    {
        var roundStartView = new RoundStartView(_view, attacker, defender, _roundNumber, _turnsManager.PlayerWhoStarts);
        roundStartView.ShowRoundStart();
    }

    private void ShowEffectsSummary(Unit attacker, Unit defender)
    {
        var effectsSummaryView = new EffectsSummaryView(_view, attacker, defender);
        effectsSummaryView.ShowEffectsSummary();
    }

    private void EndRound(Unit attacker, Unit defender)
    {
        ShowRoundSummary(attacker, defender);
        _turnsManager.SwitchTurns();
        _skillsManager.DeactivateEffects();
        _roundNumber++;
    }

    private void ShowRoundSummary(Unit attacker, Unit defender)
    {
        var roundSummaryView = new RoundSummaryView(_view, attacker, defender);
        roundSummaryView.ShowRoundSummary();
    }
}
