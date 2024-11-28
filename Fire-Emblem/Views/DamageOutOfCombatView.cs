using Fire_Emblem_View;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Enums;

namespace Fire_Emblem.Views;

public class DamageOutOfCombatView
{
    private View _view;

    public DamageOutOfCombatView(View view)
    {
        _view = view;
    }
    public void ShowDamageOutOfCombatMessages(DamageOutOfCombatInfo[] damageOutOfCombatInfos)
    {
        foreach (var damageInfo in damageOutOfCombatInfos)
        {
            ShowDamageOutOfCombatMessage(damageInfo);
        }
    }
    
    private void ShowDamageOutOfCombatMessage(DamageOutOfCombatInfo damageOutOfCombatInfo)
    {
        if (damageOutOfCombatInfo.Damage == 0)
            return;

        string message = BuildOutOfCombatDamageMessage(damageOutOfCombatInfo);
        _view.WriteLine(message);
    }
    
    private static string BuildOutOfCombatDamageMessage(DamageOutOfCombatInfo damageInfo)
    {
        string damageType = damageInfo.EffectDuration == EffectDuration.AfterCombat ? "despues del combate" : "antes de " +
            "iniciar el combate";
        string finalHp = damageInfo.EffectDuration == EffectDuration.AfterCombat ? string.Empty : $" y queda con " +
            $"{damageInfo.NewHp} HP";
        int absoluteDamage = Math.Abs(damageInfo.Damage);
        string action = damageInfo.Damage < 0 ? $"recibe {absoluteDamage} de daño" : $"recupera {absoluteDamage} HP";

        return $"{damageInfo.Unit.CharacterInfo.Name} {action} {damageType}{finalHp}";
    }
    
}