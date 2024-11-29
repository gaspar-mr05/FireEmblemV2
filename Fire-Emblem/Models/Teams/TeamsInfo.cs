

namespace Fire_Emblem.Models.Teams;

public class TeamsInfo
{
    public Team PlayerOneTeam { get; }
    public Team PlayerTwoTeam { get; }
    
    public TeamsInfo(Team playerOneTeam, Team playerTwoTeam)
    {
        PlayerOneTeam = playerOneTeam;
        PlayerTwoTeam = playerTwoTeam;
    }
    
    public Team GetAttackingTeam(int playerWhoStarts) => playerWhoStarts == 1 ? PlayerOneTeam : PlayerTwoTeam;
    public Team GetDefendingTeam(int playerWhoStarts) => playerWhoStarts == 1 ? PlayerTwoTeam : PlayerOneTeam;

    public bool AreValidTeams()
    {
        TeamValidator playerOneTeamValidator = new TeamValidator(PlayerOneTeam);
        TeamValidator playerTwoTeamValidator = new TeamValidator(PlayerTwoTeam);
        return playerOneTeamValidator.IsAValidTeam() && playerTwoTeamValidator.IsAValidTeam();
    }
    
    public bool AreTeamsAlive() => PlayerOneTeam.HasUnits() && PlayerTwoTeam.HasUnits();
    
}