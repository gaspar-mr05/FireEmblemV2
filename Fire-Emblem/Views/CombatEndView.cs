using Fire_Emblem_View;
using Fire_Emblem.Models.Teams;

namespace Fire_Emblem.Views;

public class CombatEndView
{
    private View _view;
    private Team _playerOneTeam;
    private Team _playerTwoTeam;

    public CombatEndView(View view, TeamsInfo teamsInfo)
    {
        _view = view;
        _playerOneTeam = teamsInfo.PlayerOneTeam;
        _playerTwoTeam = teamsInfo.PlayerTwoTeam;
    }

    public void ShowCombatEndMessage()
    {
        
        if (!_playerOneTeam.HasUnits())
            _view.WriteLine("Player 2 ganó");
        else if (!_playerTwoTeam.HasUnits())
            _view.WriteLine("Player 1 ganó");

    }
}