
namespace Fire_Emblem.Teams;
using Fire_Emblem.Characters;
using Fire_Emblem.Files;


public class TeamManager: Team
{
    private Team _team;
    
    public TeamManager(Team team)
    {
        _team = team;
    }
     
    
    public void EliminateDeadCharactersOfTeam()
    {
        Team unitsToRemove = _team.GetDeadUnitsOfTeam();
        for (int unitIndex = 0; unitIndex < unitsToRemove.GetTeamSize(); unitIndex++)
        {
            Unit unitToRemove = unitsToRemove.GetUnit(unitIndex);
            _team.RemoveUnit(unitToRemove);
        }
    }

    public void AddUnitToTeam(LineHandler lineHandler)
    {
        (string name, string[] skillsArray) = lineHandler.HandleLine();
        Models.Unit.Characters characters = CharactersBuilder.CreateCharactersFromJson();
        Unit unit = UnitBuilder.BuildUnit(characters.GetCharacter(name), skillsArray);
        _team.AddUnit(unit);
    }
}