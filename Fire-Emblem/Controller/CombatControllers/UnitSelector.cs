using Fire_Emblem_View;
using Fire_Emblem.Models.Teams;
using Fire_Emblem.Models.Units;
using Fire_Emblem.Views;

namespace Fire_Emblem.Controller.CombatControllers;

public class UnitSelector
{
    private View _view;

    public UnitSelector(View view)
    {
        _view = view;
    }
    

    public (Unit attacker, Unit defender) SelectUnits(TeamsInfo teamsInfo, int playerWhoStartsNumber)
    {
        int playerWhoAttacksNumber = playerWhoStartsNumber == 1? 1: 2;
        int playerWhoDefendsNumber = playerWhoStartsNumber == 1? 2: 1 ;

        Unit unitWhoAttacks = SetUnit(teamsInfo.GetAttackingTeam(playerWhoStartsNumber), playerWhoAttacksNumber);
        Unit unitWhoDefends = SetUnit(teamsInfo.GetDefendingTeam(playerWhoStartsNumber), playerWhoDefendsNumber);
        return (unitWhoAttacks, unitWhoDefends);
    }

    private Unit SetUnit(Team team, int playerNumber)
    {
        UnitOptionsView unitOptionsView = new UnitOptionsView(_view);
        int unitNumber = unitOptionsView.ShowUnitOptions(playerNumber, team);
        return team.GetUnit(unitNumber);
    }
    
}