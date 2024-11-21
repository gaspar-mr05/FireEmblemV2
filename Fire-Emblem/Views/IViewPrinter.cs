namespace Fire_Emblem.ViewPrinter;
using Fire_Emblem.Combat;
using Fire_Emblem.Characters;
using Fire_Emblem.Teams;
using Fire_Emblem_View;


public interface IViewPrinter
{
    void ShowStartRoundMessage(int roundNumber, Unit attacker, Unit defender, int playerWhoStarts);
    void ShowAdvantageMessage(Unit attacker, Unit defender);
    void ShowRoundSummary(Unit attacker, Unit defender);
}