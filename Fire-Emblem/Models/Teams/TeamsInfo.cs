

namespace Fire_Emblem.Models.Teams;

public class TeamsInfo
{
    public Teams.Team PlayerOneTeam { get; }
    public Teams.Team PlayerTwoTeam { get; }
    
    public TeamsInfo(Teams.Team playerOneTeam, Teams.Team playerTwoTeam)
    {
        PlayerOneTeam = playerOneTeam;
        PlayerTwoTeam = playerTwoTeam;
    }
    
    public Teams.Team GetAttackingTeam(int playerWhoStarts) => playerWhoStarts == 1 ? PlayerOneTeam : PlayerTwoTeam;
    public Teams.Team GetDefendingTeam(int playerWhoStarts) => playerWhoStarts == 1 ? PlayerTwoTeam : PlayerOneTeam;

    public bool AreValidTeams()
    {
        TeamValidator playerOneTeamValidator = new TeamValidator(PlayerOneTeam);
        TeamValidator playerTwoTeamValidator = new TeamValidator(PlayerTwoTeam);
        return playerOneTeamValidator.IsAValidTeam() && playerTwoTeamValidator.IsAValidTeam();
    }
    
    public bool AreTeamsAlive() => PlayerOneTeam.HasUnits() && PlayerTwoTeam.HasUnits();
    
}