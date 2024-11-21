using System.Diagnostics;

namespace Fire_Emblem.Combat;

public class TurnsManager
{
    private int _playerWhoStarts;

    public TurnsManager(int playerWhoStarts)
    {
        _playerWhoStarts = playerWhoStarts;
    }
    
    public int PlayerWhoStarts => _playerWhoStarts;

    public void SwitchTurns()
    {
        if (_playerWhoStarts == 1)
            _playerWhoStarts = 2;
        else
            _playerWhoStarts = 1;
    }
}