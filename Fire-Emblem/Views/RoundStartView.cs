using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Combat;

namespace Fire_Emblem.ViewPrinter;

public class RoundStartView
{
    private View _view;
    private int _roundNumber;
    private Unit _attacker;
    private Unit _defender;
    private int _playerWhoStarts;

    public RoundStartView(View view, Unit attacker, Unit defender, int roundNumber, int playerWhoStarts)
    {
        _view = view;
        _attacker = attacker;
        _defender = defender;
        _roundNumber = roundNumber;
        _playerWhoStarts = playerWhoStarts;
    }

    public void ShowRoundStart()
    {
        _view.WriteLine($"Round {_roundNumber}: {_attacker.CharacterInfo.Name} (Player {_playerWhoStarts}) comienza");
        ShowAdvantageMessage();

        
        
    }


    private void ShowAdvantageMessage()
    {
        AdvantageManager advantageManager = new AdvantageManager(_attacker, _defender);
        double wtb = advantageManager.CalculateWtbWithAdvantage();
        string weaponToAttack = _attacker.CharacterInfo.Weapon, weaponToDefend = _defender.CharacterInfo.Weapon;
        if (wtb == 1)
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        else
            _view.WriteLine(wtb == 1.2
                ? $"{_attacker.CharacterInfo.Name} ({weaponToAttack}) tiene ventaja con respecto " +
                  $"a {_defender.CharacterInfo.Name} ({weaponToDefend})"
                : $"{_defender.CharacterInfo.Name} ({weaponToDefend}) tiene ventaja con respecto " +
                  $"a {_attacker.CharacterInfo.Name} ({weaponToAttack})");
    }

    
}