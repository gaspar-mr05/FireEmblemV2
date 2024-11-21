using Fire_Emblem.Teams;

namespace Fire_Emblem.Combat;

public class StartCombatInfo
{
    public TeamManager PlayerOneTeamManager;
    public TeamManager PlayerTwoTeamManager;
    public RoundController RoundController;

    public StartCombatInfo(TeamManager playerOneTeamManager, TeamManager playerTwoTeamManager,
        RoundController roundController)
    {
        PlayerOneTeamManager = playerOneTeamManager;
        PlayerTwoTeamManager = playerTwoTeamManager;
        RoundController = roundController;
    }
}