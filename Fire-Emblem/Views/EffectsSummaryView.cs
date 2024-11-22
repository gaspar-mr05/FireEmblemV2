using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectsInfoBoundaries;

namespace Fire_Emblem.ViewPrinter;


public class EffectSummaryView
{
    private View _view;
    private Unit _attacker;
    private Unit _defender;
    public EffectSummaryView(View view, Unit attacker, Unit defender)
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
        ShowBonusEffectsSummary(unit);
        ShowFirstAttackBonusSummary(unit);
        ShowFollowUpAttackBonusSummary(unit);
        ShowPenaltyEffectsSummary(unit);
        ShowFirstAttackPenaltySummary(unit);
        ShowFollowUpAttackPenaltySummary(unit);
        ShowBonusNeutralizationSummary(unit);
        ShowPenaltyNeutralizationSummary(unit);
        ShowExtraDamage(unit, EffectDuration.FullRound);
        ShowExtraDamage(unit, EffectDuration.FirstAttack);
        ShowExtraDamage(unit, EffectDuration.FollowUp);
        ShowPercentageDamageReduction(unit, EffectDuration.FullRound);
        ShowPercentageDamageReduction(unit, EffectDuration.FirstAttack);
        ShowPercentageDamageReduction(unit, EffectDuration.FollowUp);
        ShowAbsoluteDamageReduction(unit, EffectDuration.FullRound);
        
    }

    private void ShowBonusEffectsSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NormalEffectInfo bonusEffectInfo = effectsSummary.BonusesInfo;
        StatEffectStatus[] statEffectStatuses = bonusEffectInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change!= 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}+{statEffectStatus.Change}");
        }
    }

    private void ShowPenaltyEffectsSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NormalEffectInfo penaltyEffectInfo = effectsSummary.PenaltiesInfo;
        StatEffectStatus[] statEffectStatuses = penaltyEffectInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change!= 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}-{statEffectStatus.Change}");
        }
    }

    private void ShowBonusNeutralizationSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NeutralizationEffectInfo bonusNeutralizationInfo = effectsSummary.BonusNeutralizationsInfo;
        (string statName, bool active)[] bonusNeutralizationEffects = bonusNeutralizationInfo.GetNeutralizationEffectSummaries();
        foreach ((string statName, bool active) in bonusNeutralizationEffects)
        {
            if (active) 
                _view.WriteLine($"Los bonus de {statName} de {unit.CharacterInfo.Name} fueron neutralizados");
        }
        
    }

    private void ShowPenaltyNeutralizationSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NeutralizationEffectInfo penaltyNeutralizationInfo = effectsSummary.PenaltyNeutralizationsInfo;
        (string statName, bool active)[] penaltyNeutralizationEffects = penaltyNeutralizationInfo.GetNeutralizationEffectSummaries();
        foreach ((string statName, bool active) in penaltyNeutralizationEffects)
        {
            if (active) 
                _view.WriteLine($"Los penalty de {statName} de {unit.CharacterInfo.Name} fueron neutralizados");
        }
    }

    private void ShowFirstAttackPenaltySummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NormalEffectInfo firstAttackPenaltyBonusInfo = effectsSummary.FirstAttackPenaltiesInfo;
        StatEffectStatus[] statEffectStatuses = firstAttackPenaltyBonusInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change != 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}{statEffectStatus.Change} " +
                                $"en su primer ataque");

        }
    }

    private void ShowFirstAttackBonusSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NormalEffectInfo firstAttackBonusInfo = effectsSummary.FirstAttackBonusesInfo;
        StatEffectStatus[] statEffectStatuses = firstAttackBonusInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change != 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}+{statEffectStatus.Change} " +
                                $"en su primer ataque");

        }
    }

    private void ShowFollowUpAttackPenaltySummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NormalEffectInfo followUpPenaltyInfo = effectsSummary.FollowUpPenaltiesInfo;
        StatEffectStatus[] statEffectStatuses = followUpPenaltyInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change != 0)
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}{statEffectStatus.Change} en su Follow-Up");

        }
    }

    private void ShowFollowUpAttackBonusSummary(Unit unit)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        NormalEffectInfo followUpBonusInfo = effectsSummary.FollowUpBonusesInfo;
        StatEffectStatus[] statEffectStatuses = followUpBonusInfo.GetEffectStatuses();
        foreach (StatEffectStatus statEffectStatus in statEffectStatuses)
        {
            if (statEffectStatus.Change != 0) 
                _view.WriteLine($"{unit.CharacterInfo.Name} obtiene {statEffectStatus.Stat}+{statEffectStatus.Change} en su Follow-Up");

        }
    }

    private void ShowAbsoluteDamageReduction(Unit unit, EffectDuration effectDuration)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        DamageEffectInfo damageEffectInfo = effectsSummary.AbsoluteDamageReductionInfo;
        DamageEffectStatus damageEffectStatus = damageEffectInfo.GetDamageInfo(effectDuration);
        if (damageEffectStatus.Damage != 0)
            if (effectDuration == EffectDuration.FullRound)
                _view.WriteLine($"{unit.CharacterInfo.Name} recibirá {damageEffectStatus.Damage} daño en cada ataque");
        
    }

    private void ShowExtraDamage(Unit unit, EffectDuration effectDuration)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        DamageEffectInfo damageEffectInfo = effectsSummary.ExtraDamageInfo;
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

    private void ShowPercentageDamageReduction(Unit unit, EffectDuration effectDuration)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        PercentageDamageEffectInfo percentageDamageEffectInfo = effectsSummary.PercentageDamageReductionInfo;
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

    private void ShowDamageOutOfCombat(Unit unit, EffectDuration effectDuration)
    {
        EffectsSummary effectsSummary = unit.EffectsSummary;
        DamageEffectInfo damageEffectInfo = effectsSummary.OutOfCombatDamageInfo;
        DamageEffectStatus damageEffectStatus = damageEffectInfo.GetDamageInfo(effectDuration);
        if (damageEffectStatus.Active)
        {
            if (effectDuration == EffectDuration.AfterCombat)
                _view.WriteLine($"{unit.CharacterInfo.Name} recibe {damageEffectStatus.Damage} de daño despues del combate");
        }
    }
}