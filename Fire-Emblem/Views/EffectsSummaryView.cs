using Fire_Emblem_View;
using Fire_Emblem.Models.Effects.EffectSummary;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;
using Fire_Emblem.Models.Enums;
using Fire_Emblem.Models.Units;

namespace Fire_Emblem.Views;


public class EffectsSummaryView
{
    private View _view;
    private Unit _attacker;
    private Unit _defender;
    public EffectsSummaryView(View view, Unit attacker, Unit defender)
    {
        _view = view;
        _attacker = attacker;
        _defender = defender;
    }
    
    public void ShowEffectsSummary()
    {
        ShowEffectsSummary(_attacker);
        ShowEffectsSummary(_defender);
        
    }

    private void ShowEffectsSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        ShowNormalEffectsSummary(unit, effectsSummary);
        ShowNeutralizationsSummary(unit, effectsSummary);
        ShowDamageEffectsSummary(unit, effectsSummary);
        ShowHealingEffectMessage(unit, effectsSummary.ActiveHealingInfo);
        ShowNegationEffectsSummary(unit, effectsSummary);
        
    }

    private void ShowNormalEffectsSummary(Unit unit, EffectsSummary effectsSummary)
    {
        ShowNormalEffectSummary(unit, effectsSummary.BonusesInfo);
        ShowAttackEffectSummary(unit, effectsSummary.FirstAttackBonusesInfo, "primer ataque");
        ShowAttackEffectSummary(unit, effectsSummary.FollowUpBonusesInfo, "Follow-Up");
        ShowNormalEffectSummary(unit, effectsSummary.PenaltiesInfo);
        ShowAttackEffectSummary(unit, effectsSummary.FirstAttackPenaltiesInfo, "primer ataque");
        ShowAttackEffectSummary(unit, effectsSummary.FollowUpPenaltiesInfo, "Follow-Up");
        
    }

    private void ShowNormalEffectSummary(Unit unit, NormalEffectInfo normalEffectInfo)
    {
        StatEffectStatus[] statEffectStatuses = normalEffectInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change > 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}+{statEffectStatus.Change}");
            else if (statEffectStatus.Change < 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}{statEffectStatus.Change}");
        }
    }
    
    private void ShowAttackEffectSummary(Unit unit, NormalEffectInfo normalEffectInfo, string type)
    {
        StatEffectStatus[] statEffectStatuses = normalEffectInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change > 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}+{statEffectStatus.Change} " +
                                $"en su {type}");
            else if (statEffectStatus.Change < 0)
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}{statEffectStatus.Change} " +
                                $"en su {type}");
            
        }
    }

    private void ShowNeutralizationsSummary(Unit unit, EffectsSummary effectsSummary)
    {
        ShowNeutralizationSummary(unit, effectsSummary.BonusNeutralizationsInfo, "bonus");
        ShowNeutralizationSummary(unit, effectsSummary.PenaltyNeutralizationsInfo, "penalty");
        
    }

 

    private void ShowNeutralizationSummary(Unit unit, NeutralizationEffectInfo neutralizationEffectInfo, string type)
    {

        (string statName, bool active)[] neutralizationEffects = neutralizationEffectInfo.GetNeutralizationEffectSummaries();
        foreach ((string statName, bool active) in neutralizationEffects)
        {
            if (active) 
                _view.WriteLine($"Los {type} de {statName} de {unit.CharacterInfo.Name} fueron neutralizados");
        }
        
    }

    private void ShowDamageEffectsSummary(Unit unit, EffectsSummary effectsSummary)
    {
        ShowExtraDamage(unit, effectsSummary.ExtraDamageInfo, EffectDuration.FullRound);
        ShowExtraDamage(unit, effectsSummary.ExtraDamageInfo, EffectDuration.FirstAttack);
        ShowExtraDamage(unit, effectsSummary.ExtraDamageInfo, EffectDuration.FollowUp);
        ShowPercentageDamageReduction(unit, effectsSummary.PercentageDamageReductionInfo, EffectDuration.FullRound);
        ShowPercentageDamageReduction(unit, effectsSummary.PercentageDamageReductionInfo, EffectDuration.FirstAttack);
        ShowPercentageDamageReduction(unit, effectsSummary.PercentageDamageReductionInfo, EffectDuration.FollowUp);
        ShowAbsoluteDamageReduction(unit, effectsSummary.AbsoluteDamageReductionInfo);
    }

    
    

    private void ShowExtraDamage(Unit unit, DamageEffectInfo damageEffectInfo, EffectDuration effectDuration)
    {
        DamageEffectStatus damageEffectStatus = damageEffectInfo.GetDamageInfo(effectDuration);
        if (damageEffectStatus.Damage != 0)
        {
            if (effectDuration == EffectDuration.FullRound)
                _view.WriteLine($"{unit.CharacterInfo.Name} realizará +{damageEffectStatus.Damage} daño extra en cada ataque");
            if (effectDuration == EffectDuration.FirstAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} realizará +{damageEffectStatus.Damage} daño extra en su primer ataque");
            
            if (effectDuration == EffectDuration.FollowUp)
                _view.WriteLine($"{unit.CharacterInfo.Name} realizará +{damageEffectStatus.Damage} daño extra en su Follow-Up");
        }
    }

    private void ShowPercentageDamageReduction(Unit unit, PercentageDamageEffectInfo percentageDamageEffectInfo, 
        EffectDuration effectDuration)
    {
        PercentageEffectStatus percentageEffectStatus = percentageDamageEffectInfo.GetPercentageReduction(effectDuration);
        int percentageToShow = (int)Math.Round(percentageEffectStatus.Percentage * 100); 
        if (percentageToShow != 0)
        {
            if (effectDuration == EffectDuration.FullRound)
                _view.WriteLine($"{unit.CharacterInfo.Name} reducirá el daño de los ataques del rival " +
                               $"en un {percentageToShow}%");
            if (effectDuration == EffectDuration.FirstAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} reducirá el daño del primer ataque del rival " +
                               $"en un {percentageToShow}%");
            if (effectDuration == EffectDuration.FollowUp)
                _view.WriteLine($"{unit.CharacterInfo.Name} reducirá el daño del Follow-Up del rival " +
                               $"en un {percentageToShow}%");
        }
    }
    
    private void ShowAbsoluteDamageReduction(Unit unit, DamageEffectInfo damageEffectInfo)
    {
        DamageEffectStatus damageEffectStatus = damageEffectInfo.GetDamageInfo(EffectDuration.FullRound);
        if (damageEffectStatus.Damage != 0)
            _view.WriteLine($"{unit.CharacterInfo.Name} recibirá {damageEffectStatus.Damage} daño en cada ataque");
        
    }


    private void ShowHealingEffectMessage(Unit unit, PercentageEffectStatus activeHealingInfo)
    {
        if (activeHealingInfo.Active)
        {
            int percentageToShow = (int)(activeHealingInfo.Percentage * 100);
            _view.WriteLine($"{unit.CharacterInfo.Name} recuperará HP igual al " + 
                            $"{percentageToShow}% del daño realizado en cada ataque");
        }
    }

    private void ShowNegationEffectsSummary(Unit unit, EffectsSummary effectsSummary)
    {
        ShowNegationOfNegationEffectMessage(unit, effectsSummary.PermitedAttackInfo, AttackType.CounterAttack);
        ShowGuaranteeEffectMessage(unit, effectsSummary.PermitedAttackInfo, AttackType.FollowUpAttack);
        ShowNegationEffectMessage(unit, effectsSummary.PermitedAttackInfo, AttackType.CounterAttack);
        ShowNegationEffectMessage(unit, effectsSummary.PermitedAttackInfo, AttackType.FollowUpAttack);
        ShowNegationOfNegationEffectMessage(unit, effectsSummary.PermitedAttackInfo ,AttackType.FollowUpAttack);
        ShowNegationOfGuaranteeEffectMessage(unit, effectsSummary.PermitedAttackInfo, AttackType.FollowUpAttack);
    }
    
    private void ShowNegationOfNegationEffectMessage(Unit unit, PermittedAttackInfo permittedAttackInfo, 
        AttackType attackType)
    {
        bool isNegationNegated = permittedAttackInfo.IsNegationNegated(attackType);
        if (isNegationNegated)
        {
            if (attackType == AttackType.CounterAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} neutraliza los efectos que previenen sus contraataques");
            if (attackType == AttackType.FollowUpAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} es inmune a los efectos que neutralizan su follow up");
        }
    }
    private void ShowGuaranteeEffectMessage(Unit unit, PermittedAttackInfo permittedAttackInfo, AttackType attackType)
    {
        int amount = permittedAttackInfo.GetAmountGuaranteed(attackType);
        if (amount > 0)
        {
            if (attackType == AttackType.FollowUpAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} tiene {amount} efecto(s) que garantiza(n) su follow up activo(s)");
        }
    }

    private void ShowNegationEffectMessage(Unit unit, PermittedAttackInfo permittedAttackInfo, AttackType attackType)
    {

        int amount = permittedAttackInfo.GetAmountNegated(attackType);
        if (amount > 0)
        {
            if (attackType == AttackType.CounterAttack)
                if (permittedAttackInfo.IsNegated(attackType))
                    _view.WriteLine($"{unit.CharacterInfo.Name} no podrá contraatacar");
            if (attackType == AttackType.FollowUpAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} tiene {amount} efecto(s) que neutraliza(n) su follow up activo(s)");
        }
    }
    
    

    
    private void ShowNegationOfGuaranteeEffectMessage(Unit unit, PermittedAttackInfo permittedAttackInfo, 
        AttackType attackType)
    {
        bool isGuaranteeNegated = permittedAttackInfo.IsGuaranteeNegated(attackType);
        if (isGuaranteeNegated)
        {
            if (attackType == AttackType.FollowUpAttack)
                _view.WriteLine($"{unit.CharacterInfo.Name} es inmune a los efectos que garantizan su follow up");
        }
    }
    

}