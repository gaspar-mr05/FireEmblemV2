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

    public void ShowAttacksMessages(string[][] attackMessages)
    {
        _effectSummaryView.ShowEffectsSummary();
        for (int i = 0; i < attackMessages.Length; i++)
        {
            ShowAttacksMessages(attackMessages[i]);
        }
    }

    private void ShowAttacksMessages(string[] attackMessages)
    {
        
        for (int i = 0; i < attackMessages.Length; i++)
        {
            string attackMessage = attackMessages[i];
            if (!(attackMessage == ""))
            {
                _view.WriteLine($"{attackMessage}");
            }
        }
        
    }
    
}