namespace Fire_Emblem.Teams;
using Fire_Emblem.Files;


public class TeamsBuilder
{
    private string[] _fileLines;
    private Team _playerOneTeam;
    private Team _playerTwoTeam;

    public TeamsBuilder(string[] fileLines)
    {
        _fileLines = fileLines;
        _playerOneTeam = new Team();
        _playerTwoTeam = new Team();

    }

    public (Team, Team) BuildTeams()
    {

        Team currentTeam = _playerOneTeam;
        foreach (string line in _fileLines)
        {
            
            if (line == "Player 1 Team")
                currentTeam = _playerOneTeam;
            else if (line == "Player 2 Team")
                currentTeam = _playerTwoTeam;
            else
            {
                LineHandler lineHandler = new LineHandler(line);
                TeamManager teamManager = new TeamManager(currentTeam);
                teamManager.AddUnitToTeam(lineHandler);
            }
        }
        return (_playerOneTeam, _playerTwoTeam);
    }
}