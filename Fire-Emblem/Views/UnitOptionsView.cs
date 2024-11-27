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

    public int ShowUnitOptions(string message, Team team)
    {
        _view.WriteLine($"{message}");
        for (int characterNumber = 0; characterNumber < team.GetTeamSize(); characterNumber++)
            _view.WriteLine($"{characterNumber}: {team.GetUnit(characterNumber).CharacterInfo.Name}");
        int unitNumber = int.Parse(_view.ReadLine());
        return unitNumber;
    }

    public void ShowInvalidTeamMessage()
    {
        _view.WriteLine("Archivo de equipos no válido");
    }
    

    

}