using Fire_Emblem.Effects;
using Fire_Emblem.Models.Effects.EffectSummary.EffectsInfoBoundaries;

namespace Fire_Emblem.Models.Effects.EffectSummary;

public class EffectsSummary
{
    public NormalEffectInfo BonusesInfo = new();
    public NormalEffectInfo PenaltiesInfo = new();
    public NormalEffectInfo FirstAttackBonusesInfo = new();
    public NormalEffectInfo FirstAttackPenaltiesInfo = new();
    public NormalEffectInfo FollowUpBonusesInfo = new();
    public NormalEffectInfo FollowUpPenaltiesInfo = new();
    public NeutralizationEffectInfo BonusNeutralizationsInfo = new();
    public NeutralizationEffectInfo PenaltyNeutralizationsInfo = new();
    public DamageEffectInfo ExtraDamageInfo = new();
    public DamageEffectInfo AbsoluteDamageReductionInfo = new();
    public PercentageDamageEffectInfo PercentageDamageReductionInfo = new();
    public PercentageEffectStatus ActiveHealingInfo = new();
    public DamageEffectInfo OutOfCombatDamageInfo = new();
    public PermittedAttackInfo PermitedAttackInfo = new();
    


}

