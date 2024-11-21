using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.ViewPrinter;

public class RoundSummaryView
{
    private View _view;
    private Unit _attacker;
    private Unit _defender;

    public RoundSummaryView(View view, Unit attacker, Unit defender)
    {
        _view = view;
        _attacker = attacker;
        _defender = defender;
    }

    public void ShowRoundSummary()
    {
        _view.WriteLine($"{_attacker.CharacterInfo.Name} ({_attacker.Stats.GetHp()}) : " +
                       $"{_defender.CharacterInfo.Name} ({_defender.Stats.GetHp()})");
    }
}