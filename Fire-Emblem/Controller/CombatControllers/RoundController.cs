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
    private View _view;
    private int _roundNumber;
    private UnitSelector _unitSelector;
    private TurnsManager _turnsManager;
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
         (AttacksController attacksManager, Unit attacker, Unit defender) = StartRound(teamsInfo);
        attacksManager.ExecuteAllAttacks(_skillsManager);
        _roundNumber = FinishRound(attacker, defender);
    }
    
    private (AttacksController, Unit, Unit) StartRound(TeamsInfo teamsInfo)
    {
        (Unit attacker, Unit defender) = SelectUnits(teamsInfo);
        InitializeEffects(attacker, defender);
        RoundInfo roundInfo = new RoundInfo(attacker, defender);
        _skillsManager = new SkillsManager(roundInfo);
        _skillsManager.ActivateEffects();
        AttacksController attacksController = CreateAttacksController(attacker, defender, roundInfo);
        ShowRoundStartView(attacker, defender);

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

    private void ShowRoundStartView(Unit attacker, Unit defender)
    {
        RoundStartView roundStartView = new RoundStartView(_view, attacker, defender, _roundNumber, 
            _turnsManager.PlayerWhoStarts);
        roundStartView.ShowRoundStart();
    }
    

    private AttacksController CreateAttacksController(Unit attacker, Unit defender, RoundInfo roundInfo)
    {
        return new AttacksController(_view, attacker, defender, roundInfo);
    }

    
    private int FinishRound(Unit attacker, Unit defender)
    {
        RoundSummaryView roundSummaryView = new RoundSummaryView(_view, attacker, defender);
        roundSummaryView.ShowRoundSummary();
        _roundNumber++;
        _turnsManager.SwitchTurns();
        _skillsManager.DeactivateEffects();
        return _roundNumber;
    }
}
