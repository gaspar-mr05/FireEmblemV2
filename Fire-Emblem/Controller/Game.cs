﻿using Fire_Emblem_View;

namespace Fire_Emblem.Controller;

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