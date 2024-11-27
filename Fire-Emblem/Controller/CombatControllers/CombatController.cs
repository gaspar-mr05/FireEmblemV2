using Fire_Emblem_View;
using Fire_Emblem.Models.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controller.CombatControllers;

public class CombatController
{
    private View _view;
    private CombatEndView _combatEndView;

    private TeamsInfo _teamsInfo;
    

    public CombatController(View view, TeamsInfo teamsInfo)
    {
        _view = view;
        _teamsInfo = teamsInfo;
        _combatEndView = new CombatEndView(view, teamsInfo);
    }

    
    
    public void ExecuteCombat()
    {
        StartCombatInfo startCombatInfo = StartCombat();
        while (_teamsInfo.AreTeamsAlive())
        {
            startCombatInfo.RoundController.ExecuteRound(_teamsInfo);
            startCombatInfo.PlayerOneTeamManager.EliminateDeadCharactersOfTeam();
            startCombatInfo.PlayerTwoTeamManager.EliminateDeadCharactersOfTeam();
        }
        
        _combatEndView.ShowCombatEndMessage();
    }
    
    private StartCombatInfo StartCombat()
    {
        TeamManager playerOneTeamManager = new TeamManager(_teamsInfo.PlayerOneTeam);
        TeamManager playerTwoTeamManager = new TeamManager(_teamsInfo.PlayerTwoTeam);
        RoundController roundController = new RoundController(_view);
        StartCombatInfo startCombatInfo = new StartCombatInfo(playerOneTeamManager, playerTwoTeamManager,
            roundController);
        return startCombatInfo;
    }








}







    
