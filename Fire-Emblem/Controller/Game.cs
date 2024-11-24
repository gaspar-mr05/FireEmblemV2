using Fire_Emblem_View;
using Fire_Emblem.Teams;
using Fire_Emblem.Combat;
using Fire_Emblem.Files;


namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;

    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    
    
    
    public void Play()
    {
        Simulation simulation = new Simulation(_view, _teamsFolder);
        simulation.StartSimulation(); 
    }
}