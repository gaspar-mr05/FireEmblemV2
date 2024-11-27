using Fire_Emblem_View;
using Fire_Emblem.Controller.CombatControllers;
using Fire_Emblem.Controller.FilesControllers;
using Fire_Emblem.Models.Exceptions;
using Fire_Emblem.Models.Teams;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controller;

public class Simulation
{
    private View _view;
    private string _teamsFolder;

    public Simulation(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;

    }
    
    public void StartSimulation()
    {
        try
        {
            TryExecuteCombat();
        }

        catch (InvalidTeamException)
        {
            UnitOptionsView unitOptionsView = new UnitOptionsView(_view);
            unitOptionsView.ShowInvalidTeamMessage();
        }
    }
    

    private void TryExecuteCombat()
    {
        TeamsInfo teamsInfo = InitializeTeams();
        if (teamsInfo.AreValidTeams())
        {
            CombatController combat = new CombatController(_view, teamsInfo);
            combat.ExecuteCombat();
        }
        
    }
    
    private TeamsInfo InitializeTeams()
    {
        FileReader fileReader = new FileReader(_view, _teamsFolder);
        string[] fileLines = fileReader.ReadFile();
        TeamsBuilder teamsBuilder = new TeamsBuilder(fileLines);
        (Team playerOneTeam, Team playerTwoTeam) = teamsBuilder.BuildTeams();
        return new TeamsInfo(playerOneTeam, playerTwoTeam);
    }
}