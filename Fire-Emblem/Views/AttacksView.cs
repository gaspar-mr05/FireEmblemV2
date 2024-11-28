using Fire_Emblem_View;
using Fire_Emblem.Models.Attacks;
using Fire_Emblem.Models.Damage;
using Fire_Emblem.Models.Enums;


public class AttacksView
{
    private readonly View _view;

    public AttacksView(View view)
    {
        _view = view;
    }
    



    public void ShowFollowUpMessage(AttackInfo attackerAttackInfo, AttackInfo defenderAttackInfo)
    {
        if (attackerAttackInfo.AttackError == AttackError.NoFollowUpIndividual)
            _view.WriteLine($"{attackerAttackInfo.Attacker.CharacterInfo.Name} no puede hacer un follow up");
        else if (BothFollowUpsFailed(attackerAttackInfo, defenderAttackInfo))
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        else
        {
            ShowAttackMessage(attackerAttackInfo);
            ShowAttackMessage(defenderAttackInfo);
        }
    }
    
    public void ShowAttackMessage(AttackInfo attackInfo)
    {
        if (IsAttackInvalid(attackInfo))
            return;

        string message = BuildDamageMessage(attackInfo);

        if (attackInfo.HpHealed > 0)
            message += BuildHealingMessage(attackInfo);

        _view.WriteLine(message);
    }
    
    
    private bool IsAttackInvalid(AttackInfo attackInfo)
    {
        return attackInfo.AttackError == AttackError.NoAttackPossible || 
               attackInfo.AttackError == AttackError.NoFollowUp;
    }
    
    private string BuildDamageMessage(AttackInfo attackInfo)
    {
        return $"{attackInfo.Attacker.CharacterInfo.Name} ataca a {attackInfo.Defender.CharacterInfo.Name}" +
               $" con {attackInfo.Damage} de daño";
    }
    
    private string BuildHealingMessage(AttackInfo attackInfo)
    {
        return $"\n{attackInfo.Attacker.CharacterInfo.Name} recupera {attackInfo.HpHealed} HP luego de atacar " +
               $"y queda con {attackInfo.Attacker.Stats.GetHp()} HP.";
    }
    
    private bool BothFollowUpsFailed(AttackInfo attackerInfo, AttackInfo defenderInfo)
    {
        return attackerInfo.AttackError == AttackError.NoFollowUp && 
               defenderInfo.AttackError == AttackError.NoFollowUp;
    }
    
 
}
