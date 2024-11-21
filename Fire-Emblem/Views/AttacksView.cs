using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.ViewPrinter;

public class AttacksView
{
    private View _view;
    private EffectSummaryView _effectSummaryView;

    public AttacksView(View view, Unit attacker, Unit defender)
    {
        _view = view;
        _effectSummaryView = new EffectSummaryView(view, attacker, defender);
    }

    public void ShowAttacksMessages(List<string> attackMessages)
    {
        _effectSummaryView.ShowEffectsSummary();
        for (int i = 0; i < attackMessages.Count; i++)
        {
            string attackMessage = attackMessages[i];
            if (!(attackMessage == ""))
            {
                _view.WriteLine($"{attackMessage}");
            }
        }
    }
    
}