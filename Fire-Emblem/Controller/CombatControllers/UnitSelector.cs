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
    

    public (Unit attacker, Unit defender) SelectUnits(TeamsInfo teamsInfo, int playerWhoStarts)
    {
        SelectionMessageGenerator selectionMessageGenerator = new SelectionMessageGenerator(playerWhoStarts);
        (string attackMessage, string defendsMessage) = selectionMessageGenerator.GenerateSelectionMessages();

        Unit unitWhoAttacks = SetUnit(teamsInfo.GetAttackingTeam(playerWhoStarts), attackMessage);
        Unit unitWhoDefends = SetUnit(teamsInfo.GetDefendingTeam(playerWhoStarts), defendsMessage);
        return (unitWhoAttacks, unitWhoDefends);
    }

    private Unit SetUnit(Team team, string message)
    {
        UnitOptionsView unitOptionsView = new UnitOptionsView(_view);
        int unitNumber = unitOptionsView.ShowUnitOptions(message, team);
        return team.GetUnit(unitNumber);
    }
    
}