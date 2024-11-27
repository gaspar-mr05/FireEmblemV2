using Fire_Emblem.Models.Exceptions;

namespace Fire_Emblem.Models.Teams;

public class TeamValidator
{
    private Team _team;

    public TeamValidator(Team team)
    {
        _team = team;
    }
    
    public bool IsAValidTeam()
    {
        
        if (IsTeamSizeValid() &&
            HasValidSkillsAndUnits())
        {
            return true;
        }
        throw new InvalidTeamException();
    }
    
    private bool IsTeamSizeValid()
    {
        int minTeamSize = 0;
        int maxTeamSize = 3;
        return _team.GetTeamSize() > minTeamSize && _team.GetTeamSize() <= maxTeamSize;
    }
    
    private bool HasValidSkillsAndUnits()
    {
        return _team.NotDuplicatedSkillsInTeam() && _team.LessThanThreeSkillsInTeam() && _team.NotDuplicatedUnitsInTeam();
    }
    

}