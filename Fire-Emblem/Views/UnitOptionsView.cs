using Fire_Emblem_View;
using Fire_Emblem.Models.Teams;

namespace Fire_Emblem.Views;

public class UnitOptionsView
{
    private View _view;

    public UnitOptionsView(View view)
    {
        _view = view;
    }

    public int ShowUnitOptions(int playerNumber, Team team)
    {
        ShowWelcome(playerNumber);
        for (int characterNumber = 0; characterNumber < team.GetTeamSize(); characterNumber++)
            _view.WriteLine($"{characterNumber}: {team.GetUnit(characterNumber).CharacterInfo.Name}");
        int unitNumber = int.Parse(_view.ReadLine());
        return unitNumber;
    }

    private void ShowWelcome(int playerNumber)
    {
        if (playerNumber == 1)
            _view.WriteLine("Player 1 selecciona una opción");
        else if (playerNumber == 2)
            _view.WriteLine( "Player 2 selecciona una opción");
        
    }

    public void ShowInvalidTeamMessage()
    {
        _view.WriteLine("Archivo de equipos no válido");
    }
    

    

}